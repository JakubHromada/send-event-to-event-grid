using AddEventToEventGrid;
using Azure;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using System.Net.Mime;
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

var jsonSerializerOptions = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

// CloudEvent with custom model serialized to JSON
var cloudEvent = new CloudEvent(
    "{topic}",
    "{type}",
    BinaryData.FromObjectAsJson(model, jsonSerializerOptions),
    MediaTypeNames.Application.Json,
    CloudEventDataFormat.Json);

await client.SendEventAsync(cloudEvent);