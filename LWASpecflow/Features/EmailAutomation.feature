Feature: Email Verification for User Registration

@SmokeTesting
  Scenario: User registers and verifies their email
    Given the user is on the registration page
    When the user registers with a valid email address
    Then an email verification link should be sent to the user's email
    And the email should contain a verification link
    When the user clicks on the verification link
    Then the user should be redirected to the email verification success page
    And the user should see a success message indicating their email has been verified
