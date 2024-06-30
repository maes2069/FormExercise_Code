# User Acceptance Testing Summary

## User Stories
- As a customer user I can submit a technical issue via an online form.
- As a staff user I can see all submitted issues in ascending order.
  
## Acceptance Criteria
- Customer is presented with an online form that requires submitter email, issue description, and due date.
- Customer receives an error and prevented from submitting if...
  - Email does not include '@' symbol.
  - Email is less than 5 characters or greater than 100 characters.
  - Description is less than 100 characters or greater than 100 characters.
  - Due date is set to the past or greater than a year from today.
 - Staff is presented with a list of issues in ascending order.
  

## Test Data
  Valid Emails:
  - test@test.com
    
  Invalid Emails:
  - test
  - t@tc
  - Test123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890@test.com

Valid Descriptions:
- I am experiencing an issue with my computer that began after a recent software update. Whenever I attempt to open my email application, it crashes immediately, displaying an error message: "Application Error: 0x80004005." I am using a MacBook Pro running macOS Monterey 12.5 and the latest version of the email client, version 15.0.

Invalid Descriptions:
- I am experiencing an issue with my computer that began after a recent software update. 
- I am experiencing an issue with my computer that began after a recent software update. Whenever I attempt to open my email application, it crashes immediately, displaying an error message: "Application Error: 0x80004005." I am using a MacBook Pro running macOS Monterey 12.5 and the latest version of the email client, version 15.0.
Steps to reproduce the issue: Open the email application. > Wait for it to load. > Observe the immediate crash and error message. I have tried restarting my computer, reinstalling the email client, and checking for additional updates, but the issue persists. Additionally, I cleared the application cache and removed any recently added plugins, but these steps did not resolve the problem.
Please find attached a screenshot of the error message. This issue is severely affecting my ability to communicate for work, so a prompt resolution would be greatly appreciated. You can reach me at my email or phone number provided in my profile, please let me know if you need any additional information. Thank you for your assistance.

Valid Due Dates:
- Tomorrow
- 08/01/2024
- 09/01/2024

Invalid Due Dates: 
- Today
- Yesterday
- 06/01/2024
- 01/01/2030
