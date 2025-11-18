# Capgemini_CodingTest
insurance premium calculator built using ASP.NET MVC, C#, and the Strategy Pattern.

This project is a Monthly Premium Calculator built using ASP.NET MVC and the Strategy Design Pattern.
The application allows users to enter personal and occupation details and instantly calculates insurance premiums based on occupation risk ratings.

🔍 Project Overview

The purpose of this project is to demonstrate:
Clean architecture using Strategy Pattern
MVC form handling and validation
Real-time premium calculation
Separation of business logic from UI
Unit testing using NUnit
 

🧮 Key Features

Form accepts Name, DOB, Age Next Birthday, Occupation, and Death Sum Insured
Occupation-based rating using Strategy Pattern
Premium automatically recalculates when occupation changes
Razor form auto-submits on occupation dropdown change
Full NUnit test coverage for strategies and premium logic
Clean and simple UI for demonstration


🧩 Strategy Pattern Usage

Each occupation rating (Professional, White Collar, Light Manual, Heavy Manual) is implemented as a separate strategy class, allowing:
Easy extension for new ratings
Better maintainability
No large conditional blocks


📘 Premium Formula
Monthly Premium =
(Death Sum Insured × Rating Factor × Age Next Birthday) / 1000 × 12



🛠 Tech Stack

ASP.NET MVC
C#
NUnit 4.4.0

📁 Folder Structure
/Controllers
/Models
/Strategies
/Views/Premium
/Tests
