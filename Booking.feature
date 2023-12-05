Feature: booking

@Auth
Scenario Outline: Auth
    When I send a POST request to "https://restful-booker.herokuapp.com/auth" with details "admin" and "password123"
    Then the response status code should 200
    
@GetIDs
Scenario Outline: Get 
    When I send a GET request to "https://restful-booker.herokuapp.com/booking" 
    Then the response status code should 200

@CreateBooking
Scenario Outline: Post
    When I send a POST request to "https://restful-booker.herokuapp.com/booking" with details: <firstname>,<lastname>,<totalprice>,<depositpaid>,<checkin>,<checkout>,<additionalneeds>
    Then the response status code should 200
    Examples:
   | firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
   | Anna      | Bilous   | 500        | false       | 2023-01-01 | 2024-01-01 | Breakfast       |

@UpdateBooking
Scenario Outline: Put
    When I send a PUT request to "https://restful-booker.herokuapp.com/booking/:id" with details:<ID>,<firstname>,<lastname>,<totalprice>,<depositpaid>,<checkin>,<checkout>,<additionalneeds>
    Then the response status code should 200
    Examples: 
| ID | firstname | lastname | totalprice | depositpaid | checkin    | checkout   | additionalneeds |
| 63 | Anna      | Bilous   | 300        | true        | 2023-01-01 | 2024-01-01 | Breakfast       |

@DeleteBooking
Scenario Outline: Delete
    When I send a DELETE request to "https://restful-booker.herokuapp.com/booking/:id" with details: <ID>
    Then the response status code should 201
    Examples: 
| ID  |
| 588 |