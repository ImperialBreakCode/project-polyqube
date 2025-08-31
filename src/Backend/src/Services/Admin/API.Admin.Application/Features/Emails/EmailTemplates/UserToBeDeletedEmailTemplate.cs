namespace API.Admin.Application.Features.Emails.EmailTemplates
{
    internal static class UserToBeDeletedEmailTemplate
    {
        private const string STYLES = """
            body {
                margin: 0;
                background-color: #111111;
            }

            table {
                border-spacing: 0;
            }

            td {
                padding: 0;
            }

            .wrapper {
                width: 100%;
                table-layout: fixed;
                background-color: #111111;
            }

            .main {
                background: linear-gradient(45deg, #1b0e35, #3b0a4d);
                margin: 0 auto;
                width: 100%;
                max-width: 600px;
                height: 500px;
                border-spacing: 0;
                font-family: sans-serif;
                color: #eeeeee;
            }
            """;

        private const string HTML = """
                                    <!DOCTYPE html
               	PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
            <html xmlns="http://www.w3.org/1999/xhtml">

               	<head>
                  		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                  		<meta http-equiv="X-UA-Compatible" content="IE=edge" />
                  		<meta name="viewport" content="width=device-width, initial-scale=1.0">
                  		<title>Account to be deleted</title>
                  		<style type="text/css">
                     		{0}
                  		</style>
               	</head>

               	<body>

                  		<center class="wrapper">

                     		<table class="main" width="100%">
                     			<tr>
                     				<td height="100px">
                     					<h1 style="text-align: center; font-weight: 300;">
                     						PolyQube Account Deletion
                     					</h1>
                     				</td>
                     			</tr>
                     			<tr>
                     				<td>
                     					<div style="height: 200px;"></div>
                     				</td>
                     			</tr>
                    			<tr>
                 					<td>
                 						<p style="text-align: center;">Your account will be deleted after 7 days</p>
                     				</td>
                     			</tr>
                     		</table>

                  		</center>

               	</body>
            """;

        internal static string Template 
            => string.Format(HTML, STYLES);
    }
}
