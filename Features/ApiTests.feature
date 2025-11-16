@api @scenario3 @all
Feature: 3-API Tests
As a app user, I want to test various HTTP Methods GET,PUT,POST,Delete for /posts end point,
so I can use them confidently
  @smoke  
  Scenario: 31- Get all posts
    When I send a GET request to "posts" endpoint
    Then I should see response status 200 for GET
    And I should see the following records with corresponding values
      | RecordNo | UserId | Id |
      |        1 |      1 |  1 |
      |        3 |      3 |  3 |
  @smoke
  Scenario: 32- POST a new post
    When I send a POST request to "posts" endpoint with following values
      | Title     | Body                |
      | Hello API | This is a test post |
    Then the response status should be 201
    Then the response should contain the title "Hello API"

  Scenario: 33- PUT update a post
    When I send a PUT request to "posts/1" endpoint with title "Updated Post"
    Then I should see response status 200

  Scenario: 34- DELETE a post
    When I send a DELETE request to "posts/1" endpoint
    Then I should see response status 200
