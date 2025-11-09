@ui
Feature: 2-Login Page Features
As a login page user, I want to check login page features 
so that I can use them confidently in future.

  @scenario21
  Scenario: 21-Verifying login page feature with Data Table Example
    Given I have navigated to home page
    When I navigated to the page "Login Page" by clicking the link "Form Authentication"
    And I enter following login details
      | Username | Password             |
      | tomsmith | SuperSecretPassword  |
      | tomsmith | SuperSecretPassword! |
    Then I should see the login success message "You logged into a secure area!"

  @scenario22
  Scenario: 22-Verifying Logout page feature
    Given I have navigated to home page
    When I navigated to the page "Login Page" by clicking the link "Form Authentication"
    And I enter following login details
      | Username | Password             |
      | tomsmith | SuperSecretPassword! |
    When I click on "Logout" button
    Then I should see the logout success message "You logged out of the secure area!"
