using System.Text.Json;
using EliteThreadsWebApp.Contracts;
using EliteThreadsWebApp.Services.Emailing.DTO;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EliteThreadsWebApp.Services.Emailing.SendGrid
{
    public class SendGridService(
        IHttpClientFactory httpClientFactory,
        IOptions<SendGridSettings> sendGridSettings
    ) : ISendGridService
    {
        public async Task SendAsync(AfterSuccessfulPaymentEvent paymentEvent)
        {
            var email = await FetchEmail(paymentEvent.OrderHeader.UserId);
            var client = new SendGridClient(sendGridSettings.Value.ApiKey);
            var from = new EmailAddress(sendGridSettings.Value.Email, "eliteThreads");
            var subject = $"Order placed with id #{paymentEvent.OrderHeader.OrderHeaderId}";
            var to = new EmailAddress(email.UserEmail, email.FullName);
            var htmlContent = await GenerateHtml(paymentEvent);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            await client.SendEmailAsync(msg);
        }

        private async Task<UserEmailDTO> FetchEmail(string userId)
        {
            var client = httpClientFactory.CreateClient("AuthClient");
            var builder = new UriBuilder(client.BaseAddress);
            builder.Path += $"/{userId}/email";
            var response = await client.GetAsync(builder.Uri);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UserEmailDTO>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        private async Task<string> GenerateHtml(AfterSuccessfulPaymentEvent paymentEvent)
        {
            string html =
                "<!DOCTYPE html> <html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"> <head> <meta charset=\"utf-8\"> <meta name=\"viewport\" content=\"width=device-width\"> <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"> <meta name=\"x-apple-disable-message-reformatting\"> <title>Order Placed</title>\r\n \r\n\r\n<style>\r\n    html,\r\n    body {\r\n        margin: 0 auto !important;\r\n        padding: 0 !important;\r\n        height: 100% !important;\r\n        width: 100% !important;\r\n    }\r\n﻿ ﻿ * { -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; } ﻿ ﻿ div[style*=\"margin: 16px 0\"] { margin: 0 !important; } ﻿ ﻿ table, td { mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; } ﻿ ﻿ table { border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto !important; } ﻿ ﻿ img { -ms-interpolation-mode: bicubic; } ﻿ ﻿ a { text-decoration: none; } ﻿ ﻿ *[x-apple-data-detectors], .unstyle-auto-detected-links *, .aBn { border-bottom: 0 !important; cursor: default !important; color: inherit !important; text-decoration: none !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } ﻿ ﻿ .a6S { display: none !important; opacity: 0.01 !important; } ﻿ ﻿ img.g-img+div { display: none !important; } ﻿ ﻿ @media only screen and (min-device-width: 320px) and (max-device-width: 374px) { udiv .email-container { min-width: 320px !important; } } ﻿ ﻿ @media only screen and (min-device-width: 375px) and (max-device-width: 413px) { udiv .email-container { min-width: 375px !important; } } ﻿ ﻿ @media only screen and (min-device-width: 414px) { u~div .email-container { min-width: 414px !important; } } </style>\r\n\r\n</head> <body width=\"100%\" style=\"margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #F1F1F1;\"> <center style=\"width: 100%; background-color: #F1F1F1;\"> <div style=\"max-width: 600px; margin: 0 auto;\" class=\"email-container\"> <table align=\"center\" role=\"presentation\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" style=\"margin: auto;\"> <tr> <td style=\"padding: 20px 0; text-align: center\"> <img src=\"https://i.imgur.com/yfDuzur.png\" alt=\"eliteThreads Logo\" width=\"128\" height=\"128\" style=\"max-width: 100%; height: auto;\"> </td> </tr> <tr> <td style=\"background-color: #ffffff;\"> <table role=\"presentation\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\"> <tr> <td style=\"padding: 40px; text-align: center;\"> <h1 style=\"margin: 0; font-size: 24px; color: #333333; font-weight: bold;\">Thank You for Your Order!</h1> </td> </tr> <tr> <td style=\"padding: 0 40px 40px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555; text-align: left;\"> <p style=\"margin: 0;\">Your order has been placed successfully. We're working hard to get your items shipped as soon as possible.</p> <p style=\"margin-top: 20px;\">If you have any questions or concerns, please don't hesitate to contact us at <a href=\"mailto:support@eliteThreads.com\" style=\"color: #009EF7;\">support@eliteThreads.com</a>.</p> </td> </tr> <tr> <td style=\"padding: 0 40px 40px; text-align: center;\"> <a href=\"#\" style=\"background-color: #009EF7; border-radius: 5px; color: #ffffff; display: inline-block; font-family: sans-serif; font-size: 15px; font-weight: bold; line-height: 45px; text-align: center; text-decoration: none; width: 200px;\">View Order Details</a> </td> </tr> <tr> <td style=\"padding: 40px; text-align: center;\"> <h2 style=\"margin: 0; font-size: 20px; color: #333333; font-weight: bold;\">Products Ordered</h2> </td> </tr> <tr> <td style=\"padding: 0 40px 40px;\"> <table style=\"width: 100%; border-spacing: 20px 0;\"> <tr> <td style=\"width: 50%; background-color: #F1F1F1; padding: 20px;\"> <img src=\"https://via.placeholder.com/200x200\" alt=\"Product 1\" style=\"max-width: 100%; height: auto;\"> <h3 style=\"margin-top: 10px; font-size: 16px; color: #333333; font-weight: bold;\">Product 1</h3> <p style=\"margin: 0; font-size: 14px; color: #555555;\">Description of Product 1</p> </td> <td style=\"width: 50%; background-color: #F1F1F1; padding: 20px;\"> <img src=\"https://via.placeholder.com/200x200\" alt=\"Product 2\" style=\"max-width: 100%; height: auto;\"> <h3 style=\"margin-top: 10px; font-size: 16px; color: #333333; font-weight: bold;\">Product 2</h3> <p style=\"margin: 0; font-size: 14px; color: #555555;\">Description of Product 2</p> </td> </tr> </table> </td> </tr> </table> </td> </tr> <tr> <td style=\"padding: 20px 0; text-align: center; font-family: sans-serif; font-size: 12px; line-height: 18px; color: #888888;\"> <p style=\"margin: 0;\">This email was sent from <a href=\"#\" style=\"color: #888888;\">eliteThreads.com</a></p> <p style=\"margin: 10px 0 0 0;\">Copyright © 2023 eliteThreads. All rights reserved.</p> </td> </tr> </table> </div> </center> </body> </html>";
            string part1 = html.Substring(
                0,
                html.IndexOf(
                    "<h2 style=\"margin: 0; font-size: 20px; color: #333333; font-weight: bold;\">Products Ordered</h2>"
                ) + 58
            );
            string part2 = html.Substring(html.IndexOf("</table>"));
            string productsSection = "";

            foreach (var detail in paymentEvent.OrderDetails)
            {
                var image = detail.OrderProduct.Image;
                var productName = detail.OrderProduct.ProductName;
                var price = detail.IndividualPrice;
                var quantity = detail.Quantity;
                var selectedColor = detail.SelectedColor;
                var selectedSize = detail.SelectedSize;

                string product =
                    $"<td style=\"width: 50%; background-color: #F1F1F1; padding: 20px;\"> \r\n"
                    + $"  <img src=\"{image}\" alt=\"{productName}\" style=\"max-width: 100%; height: auto;\"> \r\n"
                    + $"  <h3 style=\"margin-top: 10px; font-size: 16px; color: #333333; font-weight: bold;\">{productName}</h3> \r\n"
                    + $"  <p style=\"margin: 0; font-size: 18px; color: #555555;\">{price}€</p> \r\n"
                    + $"  <p style=\"margin: 0; font-size: 18px; color: #555555;\">{quantity} qty</p> \r\n"
                    + $"  <p style=\"margin: 0; font-size: 18px; color: #555555;\">Selected color: {selectedColor}</p> \r\n"
                    + $"  <p style=\"margin: 0; font-size: 18px; color: #555555;\">Selected size: {Enum.GetName(typeof(Size), selectedSize)}</p> \r\n"
                    + $"</td>";
                productsSection += product;
            }

            return part1 + productsSection + part2;
        }
    }
}
