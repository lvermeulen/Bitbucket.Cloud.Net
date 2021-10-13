![Icon](https://i.imgur.com/OsDAzyV.png)
# Bitbucket.Cloud.Net 
[![Build status](https://ci.appveyor.com/api/projects/status/e6syxlce88nlg75d?svg=true)](https://ci.appveyor.com/project/lvermeulen/bitbucket-cloud-net)
 [![license](https://img.shields.io/github/license/lvermeulen/Bitbucket.Cloud.Net.svg?maxAge=2592000)](https://github.com/lvermeulen/Bitbucket.Cloud.Net/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/v/Bitbucket.Cloud.Net.svg?maxAge=2592000)](https://www.nuget.org/packages/Bitbucket.Cloud.Net/) 
 ![](https://img.shields.io/badge/.net-4.6-yellowgreen.svg) ![](https://img.shields.io/badge/netstandard-1.6-yellowgreen.svg)

C# Client for Bitbucket Cloud

Atlassian Bitbucket API documentation is available at [https://developer.atlassian.com/bitbucket/api/2/reference/](https://developer.atlassian.com/bitbucket/api/2/reference/).

If you're looking for Bitbucket Server API, try [this repository](https://github.com/lvermeulen/Bitbucket.Net).

## Quick Start

First, add the [nuget package](https://www.nuget.org/packages/Bitbucket.Cloud.Net/) to your project.

Next you need to authenticate the Bitbucket Cloud Client. There are three options for this. 

- [AppPasswordAuthentication](./src/Bitbucket.Cloud.Net/Common/Authentication/AppPasswordAuthentication.cs)
- [BasicAuthentication](./src/Bitbucket.Cloud.Net/Common/Authentication/BasicAuthentication.cs)
- [OAuthAuthentication](./src/Bitbucket.Cloud.Net/Common/Authentication/OAuthAuthentication.cs)

### App Password Authentication

You will need to follow the steps provided by [bitbucket support](https://support.atlassian.com/bitbucket-cloud/docs/app-passwords/) to setup your account with an app password. Then you can authenticate your bitbucket client with the following example code.

```csharp
var credentials = new Bitbucket.Cloud.Net.Common.Authentication.AppPasswordAuthentication("<your_username>", "<your_app_password>");
var client = new Bitbucket.Cloud.Net.BitbucketCloudClient("https://api.bitbucket.org/", credentials);
```

### Basic Authentication

Likely the simplest method, however, it is also the least secure and users signing in via SSO may find this method challenging if not impossible.

```csharp
var credentials = new Bitbucket.Cloud.Net.Common.Authentication.BasicAuthentication("<your_username>", "<your_password>");
var client = new Bitbucket.Cloud.Net.BitbucketCloudClient("https://api.bitbucket.org/", credentials);
```

### OAuth Authentication

The following example is [thanks to yob](https://stackoverflow.com/a/60694503/1215018) for his contribution. First you must obtain an access token. You can do this using [Flurl.Http](https://flurl.dev/) which is already a dependency on this library. You can read more about this authentication method on [Bitbucket Support](https://support.atlassian.com/bitbucket-cloud/docs/use-oauth-on-bitbucket-cloud/).

```csharp
var uvalue = "your_username OR consumer_key";
var pvalue = "your_password OR consumer_secret";
var urlAccessToken = "https://bitbucket.org/site/oauth2/access_token";
var response = await urlAccessToken
                    .WithBasicAuth(uvalue, pvalue)
                    .PostUrlEncodedAsync(new
                    {
                        grant_type = "client_credentials"
                    })
                    .ReceiveJson()
                    .ConfigureAwait(false);
var token = response.access_token;
```

Once a token has been obtained, You can authenticate the Bitbucket Client as follows.

```csharp
var credentials = new Bitbucket.Cloud.Net.Common.Authentication.OAuthAuthentication(token);
var client = new Bitbucket.Cloud.Net.BitbucketCloudClient("https://api.bitbucket.org/", credentials);
```

### Example: Listing all repositories in a workspace

Once you have an authenticated bitbucket client, you can use it for several different operations. For example, the following code will list all the public repositories in the "microsoft" workspace. If your authenticated user has access to the private repositories in a workspace, those will also be listed.

```csharp
var repos = await client.GetWorkspaceRepositoriesAsync("microsoft")
                .ConfigureAwait(false);
foreach(var repo in repos)
{
    Console.WriteLine(repo.Name);
}
```

## Features
* [X] Authentication
    * [X] OAuth2
    * [X] App Passwords
    * [X] Basic
* [X] 1.0
    * [X] Group Privileges
    * [X] Groups
    * [X] Invitations
    * [X] Users
        * [X] Invitations
* [X] 2.0
    * [X] Hook Events
        * [X] Subject Type
    * [X] Pull Requests
        * [X] Selected User
    * [X] Repositories
        * [X] Workspace
            * [X] Repo Slug
                * [X] Branch Restrictions
                    * [X] Id
                * [X] Branching Model
                    * [X] Settings
                * [X] Commit
                    * [X] Commit
                        * [X] Properties
                            * [X] App Key
                                * [X] Property Name
                    * [X] Node
                        * [X] Approve
                        * [X] Comments
                            * [X] Comment Id
                        * [X] Statuses
                            * [X] Build
                                * [X] Key
                * [X] Commits
                    * [X] Revision
                * [X] Components
                    * [X] Component Id
                * [X] Default Reviewers
                    * [X] Target User Name
                * [X] Deploy Keys
                    * [X] Key Id
                * [X] Deployments
                    * [X] Deployment Uuid
                * [X] Deployments Config
                    * [X] Environments
                        * [X] Environment Uuid
                            * [X] Variables
                                * [X] Variable Uuid
                * [X] Diff
                    * [X] Spec
                * [X] Diffstat
                    * [X] Spec
                * [X] Downloads
                    * [X] Filename
                * [X] Environments
                    * [X] Environment Uuid
                        * [X] Changes
                * [X] File History
                    * [X] Node
                        * [X] Path
                * [X] Forks
                * [X] Hooks
                    * [X] Uid
                * [X] Issues
                    * [X] Export
                    * [X] Import
                    * [X] Issue Id
                        * [X] Attachments
                            * [X] Path
                        * [X] Changes
                            * [X] Change Id
                        * [X] Comments
                            * [X] Comment Id
                        * [X] Vote
                        * [X] Watch
                * [X] Milestones
                    * [X] Milestone Id
                * [X] Patch
                    * [X] Spec
                * [X] Pipelines
                    * [X] Pipeline Uuid
                        * [X] Steps
                            * [X] Step Uuid
                                * [X] Log
                                    * [X] Log Uuid
                                * [X] Test Reports
                                    * [X] Test Cases
                                        * [X] Test Case Uuid
                                            * [X] Test Case Reasons
                        * [X] Stop Pipeline
                * [X] Pipelines Config
                    * [X] Build Number
                    * [X] Schedules
                        * [X] Schedule Uuid
                            * [X] Executions
                    * [X] Ssh
                        * [X] Key Pair
                        * [X] Known Hosts
                            * [X] Known Host Uuid
                    * [X] Variables
                        * [X] Variable Uuid
                * [X] Properties
                    * [X] App Key
                        * [X] Property Name
                * [X] Pull Requests
                    * [X] Activity
                    * [X] Pull Request Id
                        * [X] Activity
                        * [X] Approve
                        * [X] Comments
                        * [X] Commits
                        * [X] Decline
                        * [X] Diff
                        * [X] Diffstat
                        * [X] Merge
                        * [X] Patch
                        * [X] Statuses
                        * [X] Properties
                            * [X] App Key
                                * [X] Property Name
                * [X] Refs
                    * [X] Branches
                        * [X] Name
                    * [X] Tags
                        * [X] Name
                * [X] Src
                    * [X] Node
                        * [X] Path
                * [X] Versions
                    * [X] Version Id
                * [X] Watchers
    * [X] Snippets
        * [X] Workspace
            * [X] Encoded Id
                * [X] Comments
                    * [X] Comment Id
                * [X] Commits
                    * [X] Revision
                * [X] Files
                    * [X] Path
                * [X] Watch
                * [X] Watchers
                * [X] Node Id
                    * [X] Files
                        * [X] Path
                * [X] Revision
                    * [X] Diff
                    * [X] Patch
    * [X] Teams
        * [X] User Name
            * [X] Followers
            * [X] Following
            * [X] Hooks
                * [X] Uid
            * ~~[X] Members~~ (deprecated)
            * [X] Permissions
                * [X] Repositories
                    * [X] Repo Slug
            * [X] Pipelines Config
                * [X] Variables
                    * [X] Variable Uuid
            * [X] Projects
                * [X] Project Key
            * [X] Repositories
            * [X] Search
                * [X] Code
    * [X] User
        * [X] Emails
            * [X] Email
        * [X] Permissions
            * [X] Repositories
            * [X] Teams
    * [X] Users
        * [X] User Name
            * ~~[X] Followers~~ (deprecated)
            * ~~[X] Following~~ (deprecated)
            * [X] Hooks
                * [X] Uid
            * ~~[X] Members~~ (deprecated)
            * [X] Pipelines Config
                * [X] Variables
                    * [X] Variable Uuid
            * [X] Repositories
            * [X] Search
                * [X] Code
            * [X] Ssh Keys
