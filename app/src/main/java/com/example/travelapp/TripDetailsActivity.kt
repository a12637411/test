package com.example.travelapp

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.travelapp.databinding.ActivityTripDetailsBinding // Import ViewBinding class
import com.example.travelapp.models.Trip

class TripDetailsActivity : AppCompatActivity() {

    private lateinit var binding: ActivityTripDetailsBinding // ViewBinding instance

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityTripDetailsBinding.inflate(layoutInflater)
        setContentView(binding.root)

        val trip: Trip? = intent.getParcelableExtra("trip")

        trip?.let {
            binding.tripTitle.text = it.title
            binding.tripDescription.text = it.description
            // Set other views using binding, e.g., binding.addToFavoritesButton.setOnClickListener {...}
        }

        binding.addToFavoritesButton.setOnClickListener {
            // Add to favorites and show Snackbar
        }

        binding.backButton.setOnClickListener {
            onBackPressed()
        }
    }
}
