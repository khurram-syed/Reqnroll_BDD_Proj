@ui
Feature: 1-HomePage Feature

  Scenario: 11-Verifying HomePage Heading and Title
    Given I have navigated to home page
    When I check title "The Internet" and heading "Welcome to the-internet"
    Then I should see them exactly the same
#   Scenario: 12-Verifying Adding and Removing Elements
#     Given I have navigated to home page
#     When I check title "The Internet" and heading "Welcome to the-internet"
#     Then I should see them exactly the same
