Feature: cats

@GetCats
Scenario Outline: Cats 
    When I send a GET request to "https://api.thecatapi.com/v1/images/search" 
    Then the response status code should 200

@GetCatsTen
Scenario Outline: GetTen
    When I send a GET request to "https://api.thecatapi.com/v1/images/search?limit=10" 
    Then the response status code should 200

@GetCatsWithKey
Scenario Outline: GetCats
    When I send a GET request to "https://api.thecatapi.com/v1/images/search?limit=10&breed_ids=beng&api_key=REPLACE_ME" 
    Then the response status code should 200

@GetCatsImageById
Scenario Outline: GetById
    When I send a GET request to "https://api.thecatapi.com/v1/images/0XYvRd7oD" 
    Then the response status code should 200