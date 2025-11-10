@ui @scenario1
Feature: 1-HomePage Feature
As a home page user, I want to check home page features 
so that I can use them confidently in future.

  @scenario11
  Scenario: 11-Verifying HomePage Heading and Title
    Given I have navigated to home page
    When I check title "The Internet" and heading "Welcome to the-internet"
    Then I should see them exactly the same

  @scenario12
  Scenario: 12-Verifying Adding and Removing Elements
    Given I have navigated to home page
    When I navigated to the page "Add/Remove Elements" by clicking the link "Add/Remove Elements"
    Then I should see the "Add Element" button
    When I click on "Add Element" button
    Then I should see the "Delete" button
