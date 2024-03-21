using AddEventToEventGrid;
using Azure;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using System.Net.Mime;
using System.Text.Json;

var client = new EventGridPublisherClient(
    new Uri("{add event grid url}/api/events"),
    new AzureKeyCredential("")); // event grid key form Azure portal

var model = new SessionMessage
{
    JobStatus = "succeeded",
    Timestamp = DateTime.Now,
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