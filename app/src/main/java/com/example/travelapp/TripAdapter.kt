package com.example.travelapp

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.travelapp.databinding.ItemTripBinding // Import ViewBinding class
import com.example.travelapp.models.Trip

class TripAdapter(
    private val trips: List<Trip>,
    private val onItemClick: (Trip) -> Unit
) : RecyclerView.Adapter<TripAdapter.TripViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TripViewHolder {
        val binding = ItemTripBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return TripViewHolder(binding)
    }

    override fun onBindViewHolder(holder: TripViewHolder, position: Int) {
        val trip = trips[position]
        holder.bind(trip)
        holder.itemView.setOnClickListener { onItemClick(trip) }
    }

    override fun getItemCount() = trips.size

    class TripViewHolder(private val binding: ItemTripBinding) : RecyclerView.ViewHolder(binding.root) {
        fun bind(trip: Trip) {
            binding.tripTitle.text = trip.title
            binding.tripDescription.text = trip.description
            // Set other views using binding, e.g., binding.imageView.setImageResource(...)
        }
    }
}
