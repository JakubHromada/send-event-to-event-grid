using AddEventToEventGrid;
using Azure;
using Azure.Core.Serialization;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using System.Text.Json;

var client = new EventGridPublisherClient(
    new Uri("{add event grid url}/api/events"),
    new AzureKeyCredential("")); // event grid key form Azure portal

var model = new TeamsNotification
{
    Subject = "test subject",
    Timestamp = DateTime.Now,
    Importance = "Low",
    Message = "Test message",
    Details = "test details",
    Country = "test country",
    ExecutingUser = "test executing user",
    Action = "test action",
    Source = "test source",
    Url = "test url",
};

var jsonSerializer = new JsonObjectSerializer(
    new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    });

// CloudEvent with custom model serialized to JSON
var cloudEvent = new CloudEvent(
    "",
    "",
    jsonSerializer.Serialize(model),
    "application/json");

client.SendEvent(cloudEvent);