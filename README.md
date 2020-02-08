![Icon](https://i.imgur.com/OsDAzyV.png)
# Bitbucket.Net 
[![Build status](https://ci.appveyor.com/api/projects/status/e6syxlce88nlg75d?svg=true)](https://ci.appveyor.com/project/lvermeulen/bitbucket-cloud-net)
 [![license](https://img.shields.io/github/license/lvermeulen/Bitbucket.Cloud.Net.svg?maxAge=2592000)](https://github.com/lvermeulen/Bitbucket.Cloud.Net/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/vpre/Bitbucket.Cloud.Net.svg?maxAge=2592000)](https://www.nuget.org/packages/Bitbucket.Cloud.Net/) 
 ![](https://img.shields.io/badge/.net-4.5.2-yellowgreen.svg) ![](https://img.shields.io/badge/netstandard-1.4-yellowgreen.svg)

C# Client for Bitbucket Cloud

## Features
* [ ] Authentication
    * [ ] OAuth2
    * [ ] App Passwords
    * [X] Basic
* [ ] 1.0
    * [ ] Group Privileges
    * [ ] Groups
    * [ ] Invitations
    * [ ] Users
        * [ ] Invitations
* [ ] 2.0
    * [ ] Addons
        * [ ] Linkers
            * [ ] Linker Key
                * [ ] Values
    * [ ] Hook Events
        * [ ] Subject Type
    * [ ] Pull Requests
    * [X] Repositories
        * [ ] Workspace
            * [X] Repo Slug
                * [X] Branch Restrictions
                    * [X] Id
                * [X] Branching Model
                    * [X] Settings
                * [ ] Commit
                    * [ ] Node
                        * [ ] Approve
                        * [ ] Statuses
                            * [ ] Build
                                * [ ] Key
                    * [ ] Revision
                    * [ ] Sha
                        * [ ] Comments
                            * [ ] Comment Id
                * [ ] Commits
                    * [ ] Revision
                * [ ] Components
                    * [ ] Component Id
                * [X] Default Reviewers
                    * [X] Target User Name
                * [X] Deploy Keys
                    * [X] Key Id
                * [ ] Deployments
                    * [ ] Deployment Uuid
                * [ ] Deployments Config
                    * [ ] Environments
                        * [ ] Environment Uuid
                            * [ ] Variables
                                * [ ] Variable Uuid
                * [ ] Diff
                    * [ ] Spec
                * [ ] Diffstat
                    * [ ] Spec
                * [X] Downloads
                    * [X] Filename
                * [ ] File History
                    * [ ] Node
                        * [ ] Path
                * [ ] Forks
                * [X] Hooks
                    * [X] Uid
                * [ ] Issues
                    * [ ] Issue Id
                        * [ ] Attachments
                            * [ ] Path
                        * [ ] Changes
                            * [ ] Change Id
                        * [ ] Comments
                            * [ ] Comment Id
                        * [ ] Vote
                        * [ ] Watch
                * [ ] Milestones
                    * [ ] Milestone Id
                * [ ] Patch
                    * [ ] Spec
                * [ ] Pipelines
                    * [ ] Pipeline Uuid
                        * [ ] Steps
                            * [ ] Step Uuid
                                * [ ] Log
                        * [ ] Stop Pipeline
                * [ ] Pipelines Config
                    * [ ] Build Number
                    * [ ] Schedules
                        * [ ] Schedule Uuid
                            * [ ] Executions
                    * [ ] Ssh
                        * [ ] Key Pair
                        * [ ] Known Hosts
                            * [ ] Known Host Uuid
                    * [ ] Variables
                        * [ ] Variable Uuid
                * [X] Properties
                    * [X] App Key
                        * [X] Property Name
                * [ ] Pull Requests
                    * [ ] Activity
                    * [ ] Pull Request Id
                        * [ ] Activity
                        * [ ] Approve
                        * [ ] Comments
                        * [ ] Commits
                        * [ ] Decline
                        * [ ] Diff
                        * [ ] Diffstat
                        * [ ] Merge
                        * [ ] Patch
                        * [ ] Statuses
                * [X] Refs
                    * [X] Branches
                        * [X] Name
                    * [X] Tags
                        * [X] Name
                * [ ] Src
                    * [ ] Node
                        * [ ] Path
                * [X] Versions
                    * [X] Version Id
                * [X] Watchers
    * [ ] Snippets
        * [ ] User Name
            * [ ] Encoded Id
                * [ ] Comments
                * [ ] Commits
                * [ ] Watch
                * [ ] Watchers
                * [ ] Node Id
                    * [ ] Files
                        * [ ] Path
                * [ ] Revision
                    * [ ] Diff
                    * [ ] Patch
    * [ ] Teams
        * [ ] User Name
            * [ ] Followers
            * [ ] Following
            * [ ] Hooks
                * [ ] Uid
            * [ ] Members
            * [ ] Permissions
                * [ ] Repositories
            * [ ] Pipelines Config
                * [ ] Variables
                    * [ ] Variable Uuid
            * [ ] Projects
                * [ ] Project Key
            * [ ] Repositories
            * [ ] Search
                * [ ] Code
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
