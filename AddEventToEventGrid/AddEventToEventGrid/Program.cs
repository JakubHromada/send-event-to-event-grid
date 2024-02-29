using AddEventToEventGrid;
using Azure;
using Azure.Messaging;
using Azure.Messaging.EventGrid;

var client = new EventGridPublisherClient(
    new Uri("{add event grid url}/api/events"),
    new AzureKeyCredential("")); // event grid key form Azure portal

var model = new TeamsNotification
{
    Subject = "",
    Timestamp = DateTime.Now,
    Importance = "",
    Message = "",
    Details = "",
    Country = "",
    ExecutingUser = "",
    Action = "",
    Source = "",
    Url = "",
};

// CloudEvent with custom model serialized to JSON
var cloudEvent = new CloudEvent("{add event grid topic}","{add event type}", model);

client.SendEvent(cloudEvent);