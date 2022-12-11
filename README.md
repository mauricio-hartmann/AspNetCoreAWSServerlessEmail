# AspNetCoreAWSServerlessEmail

Project created to send emails using AWS lambda functions and AWS SES.

## How to use

1. Configure your AWS account;
2. Put your access key and secret key in `appsettings.json` inside API project;
3. Create a SNS topic called `EmailTopic` in your AWS account;
3. Configure your email account in AWS SES and change the email address at line 26 in lambda project;
4. Build and publish the lambda function;
5. Run the API.
    * Alternatively, you can use Docker. Inside docker dolder run `docker-compose up -d`

## Request example
Send a POST request to `http://localhost:7286/email` with the body content:
```
{
    "subject": "Email test",
    "to": [
        "your.email@test.com"
    ],
    "body": "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
}
```