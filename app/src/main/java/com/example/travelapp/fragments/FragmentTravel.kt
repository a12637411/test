package com.example.travelapp.fragments

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.travelapp.TripAdapter
import com.example.travelapp.databinding.FragmentTravelBinding // Import ViewBinding class
import com.example.travelapp.models.Trip
import com.example.travelapp.network.RetrofitInstance
import com.example.travelapp.TripDetailsActivity
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class FragmentTravel : Fragment() {

    private var _binding: FragmentTravelBinding? = null
    private val binding get() = _binding!!

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentTravelBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.recyclerView.layoutManager = LinearLayoutManager(requireContext())

        fetchTrips()
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    private fun fetchTrips() {
        CoroutineScope(Dispatchers.IO).launch {
            val response = RetrofitInstance.api.getTrips()
            withContext(Dispatchers.Main) {
                binding.recyclerView.adapter = TripAdapter(response) { trip ->
                    val intent = Intent(requireContext(), TripDetailsActivity::class.java)
                    intent.putExtra("trip", trip)
                    startActivity(intent)
                }
            }
        }
    }
}
