## There are 3 ways of accessing KV
* Registering app id in AD
    * Register App
    * Use tenantid, client id, client secret
    * Give permissions for this app id in key vault "access policy"
    * Create oAuth client credentials and get access token
    * Access key vault with access token using Authorization bearer token
* Using Managed Identities with System identities
    * Applicable to one resource (like for a particular VM)
    * Enable managed identity for VM
    * In KV give the permission to this in access policy
* Using Managed Identities with User identities
    * One can create user identity and use this for any resource
    * Give the permission in KV to this user identity
    

