Weather Lookup is a simple console application built using C# and .NET that fetches real-time weather information for any city using the OpenWeather API.

🚀 Features

Search any city in the world

Supports metric, imperial, and standard units

Displays:

Temperature 🌡️

Feels like temperature

Weather condition (ex: clear sky ☀️)

Humidity 💧

Handles network and response errors safely

Uses HTTPClient and JSON Parsing

🛠️ Tech Stack
C# - Application logic

.NET-	Console app runtime

HTTPClient - Send request to weather API

System.Text.Json -	Parse JSON response

OpenWeather - API	Fetch real-time data

📌 How to Run the Project

1️⃣ Clone the repository

git clone https://github.com/<your-username>/WeatherLookup.git


2️⃣ Open the project in Visual Studio

3️⃣ Install required .NET SDK if missing

4️⃣ Add your OpenWeather API Key
(Recommended: using system environment variable)

Windows:

setx OPENWEATHER_APIKEY "YOUR_API_KEY"


5️⃣ Run the application ▶️
<img width="1672" height="754" alt="image" src="https://github.com/user-attachments/assets/60efcc78-3ef1-4bb4-9b01-cd0544591328" />


📂 Project Structure
Copy code
WeatherLookup/
 ├── Program.cs
 ├── WeatherLookup.csproj
 ├── README.md

❓ Does this project use a database?

No — Weather data is fetched live from the API each time you run it.

⚠️ Note on Security

Do not upload your API key in source code or GitHub.
Always store keys using environment variables.

📜 License

This project is free for learning and personal use.
