package com.example.travelapp.network

import com.example.travelapp.TripApiService
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitInstance {
    private const val BASE_URL = "http://192.168.43.205:3000/"

    private val retrofit by lazy {
        Retrofit.Builder()
            .baseUrl(BASE_URL)
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    }

    val api: TripApiService by lazy {
        retrofit.create(TripApiService::class.java)
    }
}
