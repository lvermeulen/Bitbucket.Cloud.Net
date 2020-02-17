using Bitbucket.Cloud.Net.Common.MultiPart;
using Xunit;

namespace Bitbucket.Cloud.Net.Tests.Common.MultiPart
{
	public class MultiPartTests
	{
		[Fact]
		public void ParseContent()
		{
			#region multipart/related

			const string content = @"HTTP/1.1 200 OK
Content-Length: 2214
Content-Type: multipart/related; start=""snippet""; boundary=""===============1438169132528273974==""
MIME-Version: 1.0

--===============1438169132528273974==
Content-Type: application/json; charset=""utf-8""
MIME-Version: 1.0
Content-ID: snippet

{
  ""links"": {
	""self"": {
	  ""href"": ""https://api.bitbucket.org/2.0/snippets/evzijst/kypj""
	},
	""html"": {
	  ""href"": ""https://bitbucket.org/snippets/evzijst/kypj""
	},
	""comments"": {
	  ""href"": ""https://api.bitbucket.org/2.0/snippets/evzijst/kypj/comments""
	},
	""watchers"": {
	  ""href"": ""https://api.bitbucket.org/2.0/snippets/evzijst/kypj/watchers""
	},
	""commits"": {
	  ""href"": ""https://api.bitbucket.org/2.0/snippets/evzijst/kypj/commits""
	}
  },
  ""id"": kypj,
  ""title"": ""My snippet"",
  ""created_on"": ""2014-12-29T22:22:04.790331+00:00"",
  ""updated_on"": ""2014-12-29T22:22:04.790331+00:00"",
  ""is_private"": false,
  ""files"": {
	""foo.txt"": {
	  ""links"": {
		""self"": {
		  ""href"": ""https://api.bitbucket.org/2.0/snippets/evzijst/kypj/files/367ab19/foo.txt""
		},
		""html"": {
		  ""href"": ""https://bitbucket.org/snippets/evzijst/kypj#file-foo.txt""
		}
	  }
	},
	""image.png"": {
	  ""links"": {
		""self"": {
		  ""href"": ""https://api.bitbucket.org/2.0/snippets/evzijst/kypj/files/367ab19/image.png""
		},
		""html"": {
		  ""href"": ""https://bitbucket.org/snippets/evzijst/kypj#file-image.png""
		}
	  }
	}
  ],
  ""owner"": {
	""username"": ""evzijst"",
	""nickname"": ""evzijst"",
	""display_name"": ""Erik van Zijst"",
	""uuid"": ""{d301aafa-d676-4ee0-88be-962be7417567}"",
	""links"": {
	  ""self"": {
		""href"": ""https://api.bitbucket.org/2.0/users/evzijst""
	  },
	  ""html"": {
		""href"": ""https://bitbucket.org/evzijst""
	  },
	  ""avatar"": {
		""href"": ""https://bitbucket-staging-assetroot.s3.amazonaws.com/c/photos/2013/Jul/31/erik-avatar-725122544-0_avatar.png""
	  }
	}
  },
  ""creator"": {
	""username"": ""evzijst"",
	""nickname"": ""evzijst"",
	""display_name"": ""Erik van Zijst"",
	""uuid"": ""{d301aafa-d676-4ee0-88be-962be7417567}"",
	""links"": {
	  ""self"": {
		""href"": ""https://api.bitbucket.org/2.0/users/evzijst""
	  },
	  ""html"": {
		""href"": ""https://bitbucket.org/evzijst""
	  },
	  ""avatar"": {
		""href"": ""https://bitbucket-staging-assetroot.s3.amazonaws.com/c/photos/2013/Jul/31/erik-avatar-725122544-0_avatar.png""
	  }
	}
  }
}

--===============1438169132528273974==
Content-Type: text/plain; charset=""us-ascii""
MIME-Version: 1.0
Content-Transfer-Encoding: 7bit
Content-ID: ""foo.txt""
Content-Disposition: attachment; filename=""foo.txt""

foo

--===============1438169132528273974==
Content-Type: image/png
MIME-Version: 1.0
Content-Transfer-Encoding: base64
Content-ID: ""image.png""
Content-Disposition: attachment; filename=""image.png""

iVBORw0KGgoAAAANSUhEUgAAABQAAAAoCAYAAAD+MdrbAAABD0lEQVR4Ae3VMUoDQRTG8ccUaW2m
TKONFxArJYJamCvkCnZTaa+VnQdJSBFl2SMsLFrEWNjZBZs0JgiL/+KrhhVmJRbCLPx4O+/DT2TB
cbblJxf+UWFVVRNsEGAtgvJxnLm2H+A5RQ93uIl+3632PZyl/skjfOn9Gvdwmlcw5aPUwimG+NT5
EnNN036IaZePUuIcK533NVfal7/5yjWeot2z9ta1cAczHEf7I+3J0ws9Cgx0fsOFpmlfwKcWPuBQ
73Oc4FHzBaZ8llq4q1mr5B2mOUCt815qYR8eB1hG2VJ7j35q4RofaH7IG+Xrf/PfJhfmwtfFYoIN
AqxFUD6OMxcvkO+UfKfkOyXfKdsv/AYCHMLVkHAFWgAAAABJRU5ErkJggg==
--===============1438169132528273974==--
";

			#endregion

			var parts = content.ParseContent();
			Assert.NotNull(parts);
		}
	}
}
