namespace API.Admin.Application.Features.Emails.EmailTemplates
{
    internal static class VerifyEmailEmailTemplate
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
                height: 600px;
                border-spacing: 0;
                font-family: sans-serif;
                color: #eeeeee;
            }

            .confirm-link {
                background-color: #dbdbdb;
                padding: 10px;
                text-align: center;
                color: #2b2b2b;
                text-decoration: none;
                border-radius: 5px;
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
                    <title>Verify your email</title>
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
                                        Email Verification
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 200px;"></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: flex; justify-content: center; text-align: center">
                                    ({1})
                                </td>
                            </tr>
                            <tr>
                                <td style="display: flex; justify-content: center; padding: 15px;">
                                    <a class="confirm-link" href="{1}" target="_top">Verify Email</a>
                                </td>
                            </tr>
                        </table>

                    </center>

                </body>
            """;

        internal static string GetTemplate(string verifyLink)
            => string.Format(HTML, STYLES, verifyLink);
    }
}
