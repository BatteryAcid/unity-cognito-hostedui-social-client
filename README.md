## Add Cognito's Hosted UI signup/login with social IDP option to Unity

This project is a Unity client that demonstrates how to use AWS Cognito's hosted UI to authenticate with 
social identity providers (like Google, Facebook, etc) as well as typical username and password.

Note: this is not a production ready implementation, but more of a jumping-off point to help you get started on your project.

To use this with your AWS setup, you have to update both [AuthenticationManager](https://github.com/BatteryAcid/unity-cognito-hostedui-social-client/blob/master/Assets/Scripts/AuthenticationManager.cs#L10) and [ApiManager](https://github.com/BatteryAcid/unity-cognito-hostedui-social-client/blob/master/Assets/Scripts/ApiManager.cs#L6) with your configuration.

## Tutorial Video  

* https://youtu.be/lzQ2rLqlqyk

## Required Plugins for AWS SDK  

* NONE
    
## 👋 Let's talk shop 👇  
[Discord] https://discord.gg/psjbBDvNBK  
[Twitter] https://twitter.com/BatteryAcidDev

## References
* [Add Social Identity Provider to User Pool] https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-social-idp.html
https://aws.amazon.com/premiumsupport/knowledge-center/cognito-google-social-identity-provider/
https://aws.amazon.com/blogs/mobile/understanding-amazon-cognito-user-pool-oauth-2-0-grants/

* [Google Cloud Create project] https://cloud.google.com/resource-manager/docs/creating-managing-projects
* [Google Cloud Setup OAuth2.0 App] https://support.google.com/cloud/answer/6158849?hl=en

* [Create API Gateway Lambda authorizer] https://docs.aws.amazon.com/apigateway/latest/developerguide/configure-api-gateway-lambda-authorization-with-console.html

* [Unity Deep linking] https://docs.unity3d.com/2021.2/Documentation/Manual/deep-linking.html
    * https://developer.apple.com/documentation/xcode/allowing-apps-and-websites-to-link-to-your-content

* [OAuth best used from browser] https://auth0.com/blog/oauth-2-best-practices-for-native-apps/
