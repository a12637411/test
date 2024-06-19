package com.example.travelapp


import com.example.travelapp.models.Trip
import retrofit2.http.GET

interface TripApiService {
    @GET("trips")
    suspend fun getTrips(): List<Trip>
}
