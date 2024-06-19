package com.example.travelapp

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import com.example.travelapp.fragments.FragmentFavorite
import com.example.travelapp.fragments.FragmentTravel
import com.google.android.material.bottomnavigation.BottomNavigationView
import android.util.Log

class HomeActivity : AppCompatActivity() {

    private lateinit var bottomNavigationView: BottomNavigationView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home)

        bottomNavigationView = findViewById(R.id.bottom_navigation)

        Log.d("HomeActivity", "Activity created")

        // Set default fragment
        if (savedInstanceState == null) {
            loadFragment(FragmentTravel())
            Log.d("HomeActivity", "Default fragment loaded")
        }

        bottomNavigationView.setOnNavigationItemSelectedListener { item ->
            Log.d("HomeActivity", "Item selected: ${item.itemId}")
            when (item.itemId) {
                R.id.home -> {
                    loadFragment(FragmentTravel())
                    true
                }
                R.id.favorite -> {
                    loadFragment(FragmentFavorite())
                    true
                }
                R.id.logout -> {
                    logout()
                    true
                }
                else -> false
            }
        }
    }

    private fun loadFragment(fragment: Fragment) {
        Log.d("HomeActivity", "Loading fragment: ${fragment.javaClass.simpleName}")
        supportFragmentManager.beginTransaction()
            .replace(R.id.fragment_container, fragment)
            .commit()
    }

    private fun logout() {
        Log.d("HomeActivity", "Logging out")
        val intent = Intent(this, LoginActivity::class.java)
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP or Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK)
        startActivity(intent)
        finish()
    }
}
