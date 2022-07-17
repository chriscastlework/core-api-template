Feature: WeatherForecast

@mytag
Scenario: Anyone can get waether information
When weather api is called
Then the result should have weather information
