# OAUTH2 HIGHLEVEL FLOW

Registration Endpoint: This endpoint should allow users to create accounts. When users access this endpoint, they provide their desired system-specific credentials (e.g., username and password) along with their Google identity.

Google OAuth2 Login: When registration endpoint is accessed, you can also provide them with an option to log in using their Google account. This involves redirecting them to Google's OAuth2 authorization endpoint, where they log in with their Google credentials and grant your application permission to access their Google identity information.

Access Google User Info: After the user grants permission, Google will redirect them back to the registration endpoint with an authorization code, which can be exchanged for an access token and use it to access the user's Google identity information, such as their email address and unique Google identifier (sub).

User Association: With the Google identity information retrieved, you can create a new user account in your system. This account would include the Google email address and any other relevant information you want to store. This associates the user's Google identity with their account in your system.

Passwordless Accounts: For users who log in using their Google account, you can create a passwordless account in your system, as they've already authenticated with Google. This way, they don't need to manage a separate password for your system.

User Data Synchronization: Depending on your application's requirements, you may also want to periodically synchronize user data between your system and Google to ensure that the user's information remains up to date.
