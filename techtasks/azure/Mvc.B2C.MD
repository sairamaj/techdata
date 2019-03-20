### Azure B2C Setup

#### Steps
* Create Active directory B2C from portal
* Link B2C to a subscription
    * Market place
    * Use Azure Active Directory
    * Create will have option to link
* Define user flows ( a user flow is how user interacts with your app , ex:signin process)
    * [creating user flows](https://docs.microsoft.com/en-us/azure/active-directory-b2c/tutorial-create-user-flows)
    * create signupsignin flow
    * search for (Azure AD B2C to get to this screen)
* Regiser Web app
    * [regiser](https://docs.microsoft.com/en-us/azure/active-directory-b2c/tutorial-register-applications#register-a-web-application)
    * Enter https://localhost:5001/signin-oidc for URL 
    * Click YES for Web and YES for implict flow (for open id)
    * Copy the app id and key 
        * Go to Keys and generate
    * appconfig
```json

 "AzureAdB2C": {
        "Instance": "https://login.microsoftonline.com/tfp",
        "Tenant": "sairamaapps.onmicrosoft.com",
        "ClientId": "<app id here>",
        "ClientSecret": "<secret here>",
        "CallbackPath": "/signin-oidc",
        "RedirectUri": "http://localhost:5000/signin-oidc",
        "Domain": "sairamaapps.onmicrosoft.com",
        "SignUpSignInPolicyId": "B2C_1_signupsignin",
        "ResetPasswordPolicyId": "",
        "EditProfilePolicyId": ""
    }
```
### Adding other social identity providers
* Add "Identity Providers" under "Azure AD B2C"
* Go to user flow defined earlier
    * Enable the idetity providers
    * Adding google (https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-setup-goog-app)

[Sample] (https://azure.microsoft.com/en-us/resources/samples/active-directory-b2c-dotnetcore-webapp/)

[Overview](https://docs.microsoft.com/en-us/azure/active-directory-b2c/active-directory-b2c-overview)

[Create B2C tenant](https://docs.microsoft.com/en-us/azure/active-directory-b2c/tutorial-create-tenant)

