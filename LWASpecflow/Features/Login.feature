Feature: User Login

Scenario Outline: Login with valid credentials
  Given the user navigates to the login page
  When the user enters username "<Username>" and password "<Password>"
  Then the login should be "<Result>"

  Examples:
    | Username  | Password  | Result       |
    | admin     | admin123  | Success      |
    | user      | user123   | Success      |
    | invalid   | wrong123  | Failure      |
