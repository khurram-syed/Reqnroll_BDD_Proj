Feature: 0-Calculator
	Simple calculator for adding two numbers without UI

  Scenario: 01-Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
