﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PubNubMessaging.Core;
using System.IO;
using System.Net;


namespace PubnubWindowsPhone.Test.UnitTest
{
    public class PubnubUnitTest : IPubnubUnitTest
    {
        private bool enableStubTest = PubnubCommon.EnableStubTest;
        private string _testClassName = "";
        private string _testCaseName = "";

        public bool EnableStubTest
        {
            get
            {
                return enableStubTest;
            }
            set
            {
                enableStubTest = value;
            }
        }

        private Dictionary<string, string> LoadWhenAClientIsPresentedThenPresenceShouldReturnReceivedMessage()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres/0/0", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres/0/13596603179264912", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel,hello_my_channel-pnpres/0/0", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel,hello_my_channel-pnpres/0/13596603179264912", "[[{\"action\": \"join\", \"timestamp\": 1355929955, \"uuid\": \"eb4c1645-1319-4425-865f-008563009d67\", \"occupancy\": 1}],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel,hello_my_channel-pnpres/0/13559006802662768", "[[],\"13559006802662768\"]");

            data.Add("/subscribe/demo-36/hello_my_channel-pnpres,hello_my_channel/0/0", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres,hello_my_channel/0/13596603179264912", "[[{\"action\": \"join\", \"timestamp\": 1355929955, \"uuid\": \"eb4c1645-1319-4425-865f-008563009d67\", \"occupancy\": 1}],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres,hello_my_channel/0/13559006802662768", "[[],\"13559006802662768\"]");

            return data;
        }

        private Dictionary<string, string> LoadWhenAClientIsPresentedThenPresenceShouldReturnCustomUUID()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres/0/0", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres/0/13596603179264912", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel,hello_my_channel-pnpres/0/0", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel,hello_my_channel-pnpres/0/13596603179264912", "[[{\"action\": \"join\", \"timestamp\": 1355929955, \"uuid\": \"mylocalmachine.mydomain.com\", \"occupancy\": 1}],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel,hello_my_channel-pnpres/0/13559006802662768", "[[],\"13559006802662768\"]");

            data.Add("/subscribe/demo-36/hello_my_channel-pnpres,hello_my_channel/0/0", "[[],\"13596603179264912\"]");
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres,hello_my_channel/0/13596603179264912", "[[{\"action\": \"join\", \"timestamp\": 1355929955, \"uuid\": \"mylocalmachine.mydomain.com\", \"occupancy\": 1}],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel-pnpres,hello_my_channel/0/13559006802662768", "[[],\"13559006802662768\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAClientIsPresentedIfHereNowIsCalledThenItShouldReturnInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/presence/sub_key/demo-36/channel/hello_my_channel", "{\"uuids\":[\"eb4c1645-1319-4425-865f-008563009d67\"],\"occupancy\":1}");
            return data;
        }

        private Dictionary<string, string> LoadWhenAClientIsPresentedIfGlobalHereNowIsCalledThenItShouldReturnInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/presence/sub_key/demo-36", "{\"status\":200,\"message\":\"OK\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"uuids\":[{\"uuid\":\"2417aac2-813f-4f2c-899e-f388033d77fd\"}],\"occupancy\":1}},\"total_channels\":1,\"total_occupancy\":1},\"service\":\"Presence\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenAClientIsPresentedIfWhereNowIsCalledThenItShouldReturnInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/presence/sub_key/demo-36/uuid/hello_my_uuid", "{\"status\":200,\"message\":\"OK\",\"payload\":{\"channels\":[\"hello_my_channel\"]},\"service\":\"Presence\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenUnencryptPublishShouldReturnSuccessCodeAndInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"Pubnub Messaging API 1\"],13557486057035336,13559006802662769]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Pubnub%20Messaging%20API%201%22", "[1,\"Sent\",\"13559014566792817\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenUnencryptObjectPublishShouldReturnSuccessCodeAndInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22foo%22%3A%22hi%21%22%2C%22bar%22%3A%5B1%2C2%2C3%2C4%2C5%5D%7D", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[{\"foo\":\"hi!\",\"bar\":[1,2,3,4,5]}],13557486057035336,13559006802662769]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenEncryptObjectPublishShouldReturnSuccessCodeAndInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22nQTUCOeyWWgWh5NRLhSlhIingu92WIQ6RFloD9rOZsTUjAhD7AkMaZJVgU7l28e2%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"nQTUCOeyWWgWh5NRLhSlhIingu92WIQ6RFloD9rOZsTUjAhD7AkMaZJVgU7l28e2\"],13559215464464812,13559215464464812]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenEncryptPublishShouldReturnSuccessCodeAndInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
#if (SILVERLIGHT || WINDOWS_PHONE || NETFX_CORE)
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22%2BBY5/miAA8aeuhVl4d13Kg%3D%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22%2BBY5%2FmiAA8aeuhVl4d13Kg%3D%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
#else
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22%2BBY5%2FmiAA8aeuhVl4d13Kg%3D%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
#endif
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"+BY5/miAA8aeuhVl4d13Kg==\"],13557486057035336,13559006802662769]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenSecretKeyWithEncryptPublishShouldReturnSuccessCodeAndInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
#if (SILVERLIGHT || WINDOWS_PHONE || NETFX_CORE)
            data.Add("/publish/demo-36/demo-36/f377f886fada25afdf617739af129c2b/hello_my_channel/0/%22f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/e462eda69685ce9ddfd5be20c7e13cab/hello_my_channel/0/%22f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/91db22a2ce85d4d4b2d6c96be732b411/hello_my_channel/0/%22f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/e462eda69685ce9ddfd5be20c7e13cab/hello_my_channel/0/%22f42pIQcWZ9zbTbH8cyLwB%2FtdvRxjFLOYcBNMVKeHS54%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
#else
            data.Add("/publish/demo-36/demo-36/f2df042fa9883d95d1f0ce5c42b69b27/hello_my_channel/0/%22f42pIQcWZ9zbTbH8cyLwB%2FtdvRxjFLOYcBNMVKeHS54%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/e462eda69685ce9ddfd5be20c7e13cab/hello_my_channel/0/%22f42pIQcWZ9zbTbH8cyLwB%2FtdvRxjFLOYcBNMVKeHS54%3D%22", "[1,\"Sent\",\"13559014566792817\"]");
#endif
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54=\"],13559191494674157,13559191494674157]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenComplexMessageObjectShouldReturnSuccessCodeAndInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
#if (SILVERLIGHT || WINDOWS_PHONE || NETFX_CORE)
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22VersionID%22%3A3.4%2C%22Timetoken%22%3A%2213601488652764619%22%2C%22OperationName%22%3A%22Publish%22%2C%22Channels%22%3A%5B%22ch1%22%5D%2C%22DemoMessage%22%3A%7B%22DefaultMessage%22%3A%22%7E%21%40%23%24%25%5E%26%2A%28%29_%2B%20%601234567890-%3D%20qwertyuiop%5B%5D//%20%7B%7D%7C%20asdfghjkl%3B%27%20%3A/%22%20zxcvbnm%2C./%20%3C%3E%3F%20%22%7D%2C%22CustomMessage%22%3A%7B%22DefaultMessage%22%3A%22Welcome%20to%20the%20world%20of%20Pubnub%20for%20Publish%20and%20Subscribe.%20Hah%21%22%7D%2C%22SampleXml%22%3A%5B%7B%22Name%22%3A%7B%22First%22%3A%22John%22%2C%22Middle%22%3A%22P.%22%2C%22Last%22%3A%22Doe%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%22123%20Duck%20Street%22%2C%22City%22%3A%22New%20City%22%2C%22State%22%3A%22New%20York%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD123%22%7D%2C%7B%22Name%22%3A%7B%22First%22%3A%22Peter%22%2C%22Middle%22%3A%22Z.%22%2C%22Last%22%3A%22Smith%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%2212%20Hollow%20Street%22%2C%22City%22%3A%22Philadelphia%22%2C%22State%22%3A%22Pennsylvania%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD456%22%7D%5D%7D", "[1,\"Sent\",\"13602210467298480\"]"); //FOR SL
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22VersionID%22%3A3.4%2C%22Timetoken%22%3A%2213601488652764619%22%2C%22OperationName%22%3A%22Publish%22%2C%22Channels%22%3A%5B%22ch1%22%5D%2C%22DemoMessage%22%3A%7B%22DefaultMessage%22%3A%22%7E%21%40%23%24%25%5E%26%2A%28%29_%2B%20%601234567890-%3D%20qwertyuiop%5B%5D//%20%7B%7D%7C%20asdfghjkl%3B%27%20%3A/%22%20zxcvbnm%2C/%20%3C%3E%3F%20%22%7D%2C%22CustomMessage%22%3A%7B%22DefaultMessage%22%3A%22Welcome%20to%20the%20world%20of%20Pubnub%20for%20Publish%20and%20Subscribe.%20Hah%21%22%7D%2C%22SampleXml%22%3A%5B%7B%22Name%22%3A%7B%22First%22%3A%22John%22%2C%22Middle%22%3A%22P.%22%2C%22Last%22%3A%22Doe%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%22123%20Duck%20Street%22%2C%22City%22%3A%22New%20City%22%2C%22State%22%3A%22New%20York%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD123%22%7D%2C%7B%22Name%22%3A%7B%22First%22%3A%22Peter%22%2C%22Middle%22%3A%22Z.%22%2C%22Last%22%3A%22Smith%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%2212%20Hollow%20Street%22%2C%22City%22%3A%22Philadelphia%22%2C%22State%22%3A%22Pennsylvania%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD456%22%7D%5D%7D", "[1,\"Sent\",\"13602210467298480\"]"); //FOR WP7. Difference where there is ./
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22VersionID%22%3A3.4%2C%22Timetoken%22%3A%2213601488652764619%22%2C%22OperationName%22%3A%22Publish%22%2C%22Channels%22%3A%5B%22ch1%22%5D%2C%22DemoMessage%22%3A%7B%22DefaultMessage%22%3A%22%7E%21%40%23%24%25%5E%26%2A%28%29_%2B%20%601234567890-%3D%20qwertyuiop%5B%5D%5C%5C%20%7B%7D%7C%20asdfghjkl%3B%27%20%3A%5C%22%20zxcvbnm%2C.%2F%20%3C%3E%3F%20%22%7D%2C%22CustomMessage%22%3A%7B%22DefaultMessage%22%3A%22Welcome%20to%20the%20world%20of%20Pubnub%20for%20Publish%20and%20Subscribe.%20Hah%21%22%7D%2C%22SampleXml%22%3A%5B%7B%22Name%22%3A%7B%22First%22%3A%22John%22%2C%22Middle%22%3A%22P.%22%2C%22Last%22%3A%22Doe%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%22123%20Duck%20Street%22%2C%22City%22%3A%22New%20City%22%2C%22State%22%3A%22New%20York%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD123%22%7D%2C%7B%22Name%22%3A%7B%22First%22%3A%22Peter%22%2C%22Middle%22%3A%22Z.%22%2C%22Last%22%3A%22Smith%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%2212%20Hollow%20Street%22%2C%22City%22%3A%22Philadelphia%22%2C%22State%22%3A%22Pennsylvania%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD456%22%7D%5D%7D", "[1,\"Sent\",\"13602210467298480\"]");
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[{\"VersionID\":3.4,\"Timetoken\":\"13601488652764619\",\"OperationName\":\"Publish\",\"Channels\":[\"ch1\"],\"DemoMessage\":{\"DefaultMessage\":\"~!@#$%^&*()_+ `1234567890-= qwertyuiop[]\\\\ {}| asdfghjkl;' :\\\" zxcvbnm,./ <>? \"},\"CustomMessage\":{\"DefaultMessage\":\"Welcome to the world of Pubnub for Publish and Subscribe. Hah!\"},\"SampleXml\":[{\"Name\":{\"First\":\"John\",\"Middle\":\"P.\",\"Last\":\"Doe\"},\"Address\":{\"Street\":\"123 Duck Street\",\"City\":\"New City\",\"State\":\"New York\",\"Country\":\"United States\"},\"ID\":\"ABCD123\"},{\"Name\":{\"First\":\"Peter\",\"Middle\":\"Z.\",\"Last\":\"Smith\"},\"Address\":{\"Street\":\"12 Hollow Street\",\"City\":\"Philadelphia\",\"State\":\"Pennsylvania\",\"Country\":\"United States\"},\"ID\":\"ABCD456\"}]}],13735400879163600,13735400879163600]");
#else
#if USE_JSONFX
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[{\"VersionID\":3.4,\"Timetoken\":\"13601488652764619\",\"OperationName\":\"Publish\",\"Channels\":[\"ch1\"],\"DemoMessage\":{\"DefaultMessage\":\"~!@#$%^&*()_+ `1234567890-= qwertyuiop[]\\\\ {}| asdfghjkl;' :\\\" zxcvbnm,./ <>? \"},\"CustomMessage\":{\"DefaultMessage\":\"Welcome to the world of Pubnub for Publish and Subscribe. Hah!\"},\"SampleXml\":[{\"ID\":\"ABCD123\",\"Name\":{\"First\":\"John\",\"Middle\":\"P.\",\"Last\":\"Doe\"},\"Address\":{\"Street\":\"123 Duck Street\",\"City\":\"New City\",\"State\":\"New York\",\"Country\":\"United States\"}},{\"ID\":\"ABCD456\",\"Name\":{\"First\":\"Peter\",\"Middle\":\"Z.\",\"Last\":\"Smith\"},\"Address\":{\"Street\":\"12 Hollow Street\",\"City\":\"Philadelphia\",\"State\":\"Pennsylvania\",\"Country\":\"United States\"}}]}],13735400879163600,13735400879163600]"); //JsonFX
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22VersionID%22%3A3.4%2C%22Timetoken%22%3A%2213601488652764619%22%2C%22OperationName%22%3A%22Publish%22%2C%22Channels%22%3A%5B%22ch1%22%5D%2C%22DemoMessage%22%3A%7B%22DefaultMessage%22%3A%22%7E%21%40%23%24%25%5E%26%2A%28%29_%2B%20%601234567890-%3D%20qwertyuiop%5B%5D%5C%5C%20%7B%7D%7C%20asdfghjkl%3B%27%20%3A%5C%22%20zxcvbnm%2C.%2F%20%3C%3E%3F%20%22%7D%2C%22CustomMessage%22%3A%7B%22DefaultMessage%22%3A%22Welcome%20to%20the%20world%20of%20Pubnub%20for%20Publish%20and%20Subscribe.%20Hah%21%22%7D%2C%22SampleXml%22%3A%5B%7B%22ID%22%3A%22ABCD123%22%2C%22Name%22%3A%7B%22First%22%3A%22John%22%2C%22Middle%22%3A%22P.%22%2C%22Last%22%3A%22Doe%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%22123%20Duck%20Street%22%2C%22City%22%3A%22New%20City%22%2C%22State%22%3A%22New%20York%22%2C%22Country%22%3A%22United%20States%22%7D%7D%2C%7B%22ID%22%3A%22ABCD456%22%2C%22Name%22%3A%7B%22First%22%3A%22Peter%22%2C%22Middle%22%3A%22Z.%22%2C%22Last%22%3A%22Smith%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%2212%20Hollow%20Street%22%2C%22City%22%3A%22Philadelphia%22%2C%22State%22%3A%22Pennsylvania%22%2C%22Country%22%3A%22United%20States%22%7D%7D%5D%7D", "[1,\"Sent\",\"13602210467298480\"]"); //JsonFx
#else
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[{\"VersionID\":3.4,\"Timetoken\":\"13601488652764619\",\"OperationName\":\"Publish\",\"Channels\":[\"ch1\"],\"DemoMessage\":{\"DefaultMessage\":\"~!@#$%^&*()_+ `1234567890-= qwertyuiop[]\\\\ {}| asdfghjkl;' :\\\" zxcvbnm,./ <>? \"},\"CustomMessage\":{\"DefaultMessage\":\"Welcome to the world of Pubnub for Publish and Subscribe. Hah!\"},\"SampleXml\":[{\"Name\":{\"First\":\"John\",\"Middle\":\"P.\",\"Last\":\"Doe\"},\"Address\":{\"Street\":\"123 Duck Street\",\"City\":\"New City\",\"State\":\"New York\",\"Country\":\"United States\"},\"ID\":\"ABCD123\"},{\"Name\":{\"First\":\"Peter\",\"Middle\":\"Z.\",\"Last\":\"Smith\"},\"Address\":{\"Street\":\"12 Hollow Street\",\"City\":\"Philadelphia\",\"State\":\"Pennsylvania\",\"Country\":\"United States\"},\"ID\":\"ABCD456\"}]}],13735400879163600,13735400879163600]"); //Newton Json.NET
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22VersionID%22%3A3.4%2C%22Timetoken%22%3A%2213601488652764619%22%2C%22OperationName%22%3A%22Publish%22%2C%22Channels%22%3A%5B%22ch1%22%5D%2C%22DemoMessage%22%3A%7B%22DefaultMessage%22%3A%22%7E%21%40%23%24%25%5E%26%2A%28%29_%2B%20%601234567890-%3D%20qwertyuiop%5B%5D%5C%5C%20%7B%7D%7C%20asdfghjkl%3B%27%20%3A%5C%22%20zxcvbnm%2C.%2F%20%3C%3E%3F%20%22%7D%2C%22CustomMessage%22%3A%7B%22DefaultMessage%22%3A%22Welcome%20to%20the%20world%20of%20Pubnub%20for%20Publish%20and%20Subscribe.%20Hah%21%22%7D%2C%22SampleXml%22%3A%5B%7B%22Name%22%3A%7B%22First%22%3A%22John%22%2C%22Middle%22%3A%22P.%22%2C%22Last%22%3A%22Doe%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%22123%20Duck%20Street%22%2C%22City%22%3A%22New%20City%22%2C%22State%22%3A%22New%20York%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD123%22%7D%2C%7B%22Name%22%3A%7B%22First%22%3A%22Peter%22%2C%22Middle%22%3A%22Z.%22%2C%22Last%22%3A%22Smith%22%7D%2C%22Address%22%3A%7B%22Street%22%3A%2212%20Hollow%20Street%22%2C%22City%22%3A%22Philadelphia%22%2C%22State%22%3A%22Pennsylvania%22%2C%22Country%22%3A%22United%20States%22%7D%2C%22ID%22%3A%22ABCD456%22%7D%5D%7D", "[1,\"Sent\",\"13602210467298480\"]"); //Newton Json.NET
#endif
#endif
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenOptionalSecretKeyShouldBeProvidedInConstructor()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/publish/demo-36/demo-36/20881fd95e10c440b24f79baf0e4cdb7/hello_my_channel/0/%22Pubnub%20API%20Usage%20Example%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/154de00ed4a7a76b4dc4a83906d05bab/hello_my_channel/0/%22Pubnub%20API%20Usage%20Example%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/cd8eab92c8b4ec5ef50c30d89687fe72/hello_my_channel/0/%22Pubnub%20API%20Usage%20Example%22", "[1,\"Sent\",\"13559014566792817\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedIfSSLNotProvidedThenDefaultShouldBeFalse()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Pubnub%20API%20Usage%20Example%22", "[1,\"Sent\",\"13559014566792817\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenDisableJsonEncodeShouldSendSerializedObjectMessage()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
#if (SILVERLIGHT || WINDOWS_PHONE)
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22operation%22%3A%22ReturnData%22%2C%22channel%22%3A%22Mobile1%22%2C%22sequenceNumber%22%3A0%2C%22data%22%3A%5B%22ping%201.0.0.1%22%5D%7D", "[1,\"Sent\",\"13602210467298480\"]");
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[{\"operation\":\"ReturnData\",\"channel\":\"Mobile1\",\"sequenceNumber\":0,\"data\":[\"ping 1.0.0.1\"]}],13651583681093356,13651583681093356]");
#else
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%7B%22operation%22%3A%22ReturnData%22%2C%22channel%22%3A%22Mobile1%22%2C%22sequenceNumber%22%3A0%2C%22data%22%3A%5B%22ping%201.0.0.1%22%5D%7D", "[1,\"Sent\",\"13602210467298480\"]");
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[{\"operation\":\"ReturnData\",\"channel\":\"Mobile1\",\"sequenceNumber\":0,\"data\":[\"ping 1.0.0.1\"]}],13651583681093356,13651583681093356]");
#endif
            return data;
        }

        private Dictionary<string, string> LoadWhenAMessageIsPublishedThenLargeMessageShoudFailWithMessageTooLargeInfo()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
#if (SILVERLIGHT || WINDOWS_PHONE)
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20/%22red%20line/%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say./%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C/%22%20he%20said.%20/%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need./%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20/%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin./%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20/%22chain%20of%20custody/%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20%22", "[0,\"Message Too Large\",\"13559014566792817\"]"); //FOR SL
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20/%22red%20line/%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say/%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C/%22%20he%20said.%20/%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need/%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20/%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin/%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20/%22chain%20of%20custody/%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20%22", "[0,\"Message Too Large\",\"13559014566792817\"]"); // FOR WP7. Difference where there is ./
#elif NETFX_CORE
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%20We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%20We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20red%20line%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%20he%20said.%20What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20chain%20of%20custody%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TWO..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20THREE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FOUR..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FIVE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SIX..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SEVEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20EIGHT..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20NINE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20ELEVEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20THIRTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FOURTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FIFTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SIXTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SEVENTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20EIGHTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20NINETEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TWENTY..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TWENTY%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20alpha%20beta%2012%20%20TWENTY%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20alpha%20beta%2012%20TWENTY%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20alpha%20beta%2012%20TWENTY%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20alpha%20beta%2012%20TWENTY%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20alpha%20beta%2012%22", "[0,\"Message Too Large\",\"13559014566792817\"]");
#else
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20Numerous%20questions%20remain%20about%20the%20origins%20of%20the%20chemical%20and%20what%20impact%20its%20apparent%20use%20could%20have%20on%20the%20ongoing%20Syrian%20civil%20war%20and%20international%20involvement%20in%20it.When%20asked%20if%20the%20intelligence%20community%27s%20conclusion%20pushed%20the%20situation%20across%20President%20Barack%20Obama%27s%20%5C%22red%20line%5C%22%20that%20could%20potentially%20trigger%20more%20U.S.%20involvement%20in%20the%20Syrian%20civil%20war%2C%20Hagel%20said%20it%27s%20too%20soon%20to%20say.%5C%22We%20need%20all%20the%20facts.%20We%20need%20all%20the%20information%2C%5C%22%20he%20said.%20%5C%22What%20I%27ve%20just%20given%20you%20is%20what%20our%20intelligence%20community%20has%20said%20they%20know.%20As%20I%20also%20said%2C%20they%20are%20still%20assessing%20and%20they%20are%20still%20looking%20at%20what%20happened%2C%20who%20was%20responsible%20and%20the%20other%20specifics%20that%20we%27ll%20need.%5C%22%20In%20a%20letter%20sent%20to%20lawmakers%20before%20Hagel%27s%20announcement%2C%20the%20White%20House%20said%20that%20intelligence%20analysts%20have%20concluded%20%5C%22with%20varying%20degrees%20of%20confidence%20that%20the%20Syrian%20regime%20has%20used%20chemical%20weapons%20on%20a%20small%20scale%20in%20Syria%2C%20specifically%20the%20chemical%20agent%20sarin.%5C%22%20In%20the%20letter%2C%20signed%20by%20White%20House%20legislative%20affairs%20office%20Director%20Miguel%20Rodriguez%2C%20the%20White%20House%20said%20the%20%5C%22chain%20of%20custody%5C%22%20of%20the%20chemicals%20was%20not%20clear%20and%20that%20intelligence%20analysts%20could%20not%20confirm%20the%20circumstances%20under%20which%20the%20sarin%20was%20used%2C%20including%20the%20role%20of%20Syrian%20President%20Bashar%20al-Assad%27s%20regime.%20Read%20Rodriguez%27s%20letter%20to%20Levin%20%28PDF%29%20But%2C%20the%20letter%20said%2C%20%5C%22we%20do%20believe%20that%20any%20use%20of%20chemical%20weapons%20in%20Syria%20would%20very%20likely%20have%20originated%20with%20the%20Assad%20regime.%5C%22%20The%20Syrian%20government%20has%20been%20battling%20a%20rebellion%20for%20more%20than%20two%20years%2C%20bringing%20international%20condemnation%20of%20the%20regime%20and%20pleas%20for%20greater%20international%20assistance.%20The%20United%20Nations%20estimated%20in%20February%20that%20more%20than%2070%2C000%20people%20had%20died%20since%20the%20conflict%20began.%20The%20administration%20is%20%5C%22pressing%20for%20a%20comprehensive%20United%20Nations%20investigation%20that%20can%20credibly%20evaluate%20the%20evidence%20and%20establish%20what%20took%20place%2C%5C%22%20the%20White%20House%20letter%20said.%20Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TWO..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20THREE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FOUR..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FIVE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SIX..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SEVEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20EIGHT..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20NINE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20ELEVEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20THIRTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FOURTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20FIFTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SIXTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20SEVENTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20EIGHTEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20NINETEEN..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TWENTY..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20TWENTY%20ONE..Sen.%20John%20McCain%2C%20one%20of%20the%20lawmakers%20who%20received%20the%20letter%2C%20said%20the%20use%20of%20chemical%20weapons%20was%20only%20a%20matter%20of%20time.%20alpha%20beta%2012%22", "[0,\"Message Too Large\",\"13559014566792817\"]");
#endif
            return data;
        }

        private Dictionary<string, string> LoadWhenDetailedHistoryIsRequestedDetailHistoryCount10ReturnsRecords()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54=\",\"Pubnub API Usage Example\",\"nQTUCOeyWWgWh5NRLhSlhIingu92WIQ6RFloD9rOZsTUjAhD7AkMaZJVgU7l28e2\",\"Pubnub API Usage Example\",\"nQTUCOeyWWgWh5NRLhSlhIingu92WIQ6RFloD9rOZsTUjAhD7AkMaZJVgU7l28e2\",\"+BY5/miAA8aeuhVl4d13Kg==\",\"Pubnub API Usage Example\",\"f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54=\",{\"foo\":\"hi!\",\"bar\":[1,2,3,4,5]},\"Pubnub Messaging API 1\"],13559191494674157,13559319777162196]");
            return data;
        }

        private Dictionary<string, string> LoadWhenDetailedHistoryIsRequestedDetailHistoryCount10ReverseTrueReturnsRecords()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"Pubnub API Usage Example\",\"nQTUCOeyWWgWh5NRLhSlhIingu92WIQ6RFloD9rOZsTUjAhD7AkMaZJVgU7l28e2\",\"+BY5/miAA8aeuhVl4d13Kg==\",\"Pubnub API Usage Example\",\"f42pIQcWZ9zbTbH8cyLwB/tdvRxjFLOYcBNMVKeHS54=\",{\"foo\":\"hi!\",\"bar\":[1,2,3,4,5]},\"Pubnub Messaging API 1\",\"DetailedHistoryStartTimeWithReverseTrue 13557486100000000 0\",\"DetailedHistoryStartTimeWithReverseTrue 13557486100000000 1\",\"DetailedHistoryStartTimeWithReverseTrue 13557486100000000 3\"],13557486057035336,13557486128690220]");
            return data;
        }

        private Dictionary<string, string> LoadWhenDetailedHistoryIsRequestedDetailedHistoryStartWithReverseTrue()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v2/history/sub-key/demo-36/channel/hello_my_channel", "[[\"DetailedHistoryStartTimeWithReverseTrue 0\",\"DetailedHistoryStartTimeWithReverseTrue 1\",\"DetailedHistoryStartTimeWithReverseTrue 2\",\"DetailedHistoryStartTimeWithReverseTrue 3\",\"DetailedHistoryStartTimeWithReverseTrue 4\",\"DetailedHistoryStartTimeWithReverseTrue 5\",\"DetailedHistoryStartTimeWithReverseTrue 6\",\"DetailedHistoryStartTimeWithReverseTrue 7\",\"DetailedHistoryStartTimeWithReverseTrue 8\",\"DetailedHistoryStartTimeWithReverseTrue 9\"],13559326456056557,13559327017296315]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%200%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%201%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%202%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%203%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%204%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%205%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%206%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%207%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%208%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22DetailedHistoryStartTimeWithReverseTrue%209%22", "[1,\"Sent\",\"13559014566792817\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenGetRequestServerTimeThenItShouldReturnTimeStamp()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/time/0", "[13559011090230537]");
            return data;
        }

        private Dictionary<string, string> LoadWhenGetRequestServerTimeThenWithProxyItShouldReturnTimeStamp()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/time/0", "[13559011090230537]");
            return data;
        }

        private Dictionary<string, string> LoadWhenSubscribedToAChannelThenSubscribeShouldReturnReceivedMessage()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Test%20for%20WhenSubscribedToAChannel%20ThenItShouldReturnReceivedMessage%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13559006802662768", "[[\"Test for WhenSubscribedToAChannel ThenItShouldReturnReceivedMessage\"],\"13559014566792816\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13559014566792816", "[[],\"13559014566792816\"]");
            data.Add("/v2/presence/sub_key/demo-36/channel/hello_my_channel/leave", "{\"action\": \"leave\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenSubscribedToAChannelThenSubscribeShouldReturnConnectStatus()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/publish/demo-36/demo-36/0/hello_my_channel/0/%22Test%20for%20WhenSubscribedToAChannel%20ThenItShouldReturnReceivedMessage%22", "[1,\"Sent\",\"13559014566792817\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13559006802662768", "[[\"Test for WhenSubscribedToAChannel ThenItShouldReturnReceivedMessage\"],\"13559014566792816\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13559014566792816", "[[],\"13559014566792816\"]");
            data.Add("/v2/presence/sub_key/demo-36/channel/hello_my_channel/leave", "{\"action\": \"leave\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenSubscribedToAChannelThenMultiSubscribeShouldReturnConnectStatus()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/subscribe/demo-36/hello_my_channel1/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel1/0/13559006802662768", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel1,hello_my_channel2/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel1,hello_my_channel2/0/13559006802662768", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel2,hello_my_channel1/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel2,hello_my_channel1/0/13559006802662768", "[[],\"13559006802662768\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenSubscribedToAChannelThenDuplicateChannelShouldReturnAlreadySubscribed()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/subscribe/demo-36/hello_my_channel/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13559006802662768", "[[],\"13559006802662768\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenSubscribedToAChannelThenSubscriberShouldBeAbleToReceiveManyMessages()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/subscribe/demo-36/hello_my_channel/0/0", "[[],\"13602645380839594\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13602645380839594", "[[\"742730406\",\"1853970548\",\"1899616327\",\"1043229779\",\"1270838952\",\"788288787\",\"627599385\",\"1517373321\",\"1202317119\",\"184893837\"],\"13602645382888692\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13602645382888692", "[[],\"13602645382888692\"]");
            data.Add("/v2/presence/sub_key/demo-36/channel/hello_my_channel/leave", "{\"action\": \"leave\"}");
            return data;
        }


        private Dictionary<string, string> LoadWhenUnsubscribedToAChannelThenShouldReturnUnsubscribedMessage()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/subscribe/demo-36/hello_my_channel/0/0", "[[],\"13559006802662768\"]");
            data.Add("/subscribe/demo-36/hello_my_channel/0/13559006802662768", "[[],\"13559006802662768\"]");
            return data;
        }

        private Dictionary<string, string> LoadWhenAuditIsRequestedThenSubKeyLevelShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/audit/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/audit/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{},\"subscribe_key\":\"demo-36\",\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenAuditIsRequestedThenChannelLevelShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/audit/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/audit/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenSubKeyLevelWithReadWriteShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"r\":1,\"ttl\":5,\"w\":1,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"demo-36\",\"r\":1,\"ttl\":5,\"w\":1,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenSubKeyLevelWithReadShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"r\":1,\"ttl\":5,\"w\":0,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"demo-36\",\"r\":1,\"ttl\":5,\"w\":0,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenSubKeyLevelWithWriteShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"r\":0,\"ttl\":5,\"w\":1,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"demo-36\",\"r\":0,\"ttl\":5,\"w\":1,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenChannelLevelWithReadWriteShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenChannelLevelWithReadShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":0}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":0}},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenChannelLevelWithWriteShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":0,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":0,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenUserLevelWithReadWriteShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"hello_my_authkey\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"hello_my_authkey\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenUserLevelWithReadShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"hello_my_authkey\":{\"r\":1,\"w\":0}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"hello_my_authkey\":{\"r\":1,\"w\":0}},\"subscribe_key\":\"demo-36\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenUserLevelWithWriteShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"hello_my_authkey\":{\"r\":0,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"hello_my_authkey\":{\"r\":0,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenMultipleChannelGrantShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"csharp-hello_my_channel-4\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-1\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-0\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-3\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-2\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"ttl\":5,\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"csharp-hello_my_channel-4\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-1\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-0\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-3\":{\"r\":1,\"w\":1},\"csharp-hello_my_channel-2\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"demo-36\",\"ttl\":5,\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenMultipleAuthGrantShouldReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"csharp-auth_key-2\":{\"r\":1,\"w\":1},\"csharp-auth_key-3\":{\"r\":1,\"w\":1},\"csharp-auth_key-0\":{\"r\":1,\"w\":1},\"csharp-auth_key-1\":{\"r\":1,\"w\":1},\"csharp-auth_key-4\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"user\",\"channel\":\"hello_my_channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{\"csharp-auth_key-2\":{\"r\":1,\"w\":1},\"csharp-auth_key-3\":{\"r\":1,\"w\":1},\"csharp-auth_key-0\":{\"r\":1,\"w\":1},\"csharp-auth_key-1\":{\"r\":1,\"w\":1},\"csharp-auth_key-4\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"user\",\"channel\":\"hello_my_channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenRevokeAtSubKeyLevelReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"r\":0,\"ttl\":5,\"w\":0,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"subscribe_key\":\"demo-36\",\"r\":0,\"ttl\":5,\"w\":0,\"level\":\"subkey\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenRevokeAtChannelLevelReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadWhenGrantIsRequestedThenRevokeAtUserLevelReturnSuccess()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"ttl\":5,\"auths\":{},\"subscribe_key\":\"demo-36\",\"level\":\"user\",\"channel\":\"hello_my_authchannel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadGrantRequestUnitTestInit()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        private Dictionary<string, string> LoadGrantRequestUnitTestInit2()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("/v1/auth/grant/sub-key/sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":1},\"hello_my_channel-pnpres\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"sub-c-a478dd2a-c33d-11e2-883f-02ee2ddab7fe\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            data.Add("/v1/auth/grant/sub-key/demo-36", "{\"status\":200,\"message\":\"Success\",\"payload\":{\"channels\":{\"hello_my_channel\":{\"r\":1,\"w\":1},\"hello_my_channel-pnpres\":{\"r\":1,\"w\":1}},\"subscribe_key\":\"demo-36\",\"level\":\"channel\"},\"service\":\"Access Manager\"}");
            return data;
        }

        public string GetStubResponse(HttpWebRequest request)
        {
            Uri requestUri = request.RequestUri;

            Dictionary<string, string> responseDictionary = null;
            string stubResponse = "!! Stub Response Not Assigned !!";
            System.Diagnostics.Debug.WriteLine(string.Format("{0} - {1}", _testClassName, _testCaseName));
            switch (_testClassName)
            {
                case "GrantRequestUnitTest":
                    switch (_testCaseName)
                    {
                        case "Init":
                            responseDictionary = LoadGrantRequestUnitTestInit();
                            break;
                        case "Init2":
                            responseDictionary = LoadGrantRequestUnitTestInit2();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenAClientIsPresented":
                    switch (_testCaseName)
                    {
                        case "ThenPresenceShouldReturnReceivedMessage":
                            responseDictionary = LoadWhenAClientIsPresentedThenPresenceShouldReturnReceivedMessage();
                            break;
                        case "ThenPresenceShouldReturnCustomUUID":
                            responseDictionary = LoadWhenAClientIsPresentedThenPresenceShouldReturnCustomUUID();
                            break;
                        case "IfHereNowIsCalledThenItShouldReturnInfo":
                            responseDictionary = LoadWhenAClientIsPresentedIfHereNowIsCalledThenItShouldReturnInfo();
                            break;
                        case "IfGlobalHereNowIsCalledThenItShouldReturnInfo":
                            responseDictionary = LoadWhenAClientIsPresentedIfGlobalHereNowIsCalledThenItShouldReturnInfo();
                            break;
                        case "IfWhereNowIsCalledThenItShouldReturnInfo":
                            responseDictionary = LoadWhenAClientIsPresentedIfWhereNowIsCalledThenItShouldReturnInfo();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenAMessageIsPublished":
                    switch (_testCaseName)
                    {
                        case "ThenUnencryptPublishShouldReturnSuccessCodeAndInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenUnencryptPublishShouldReturnSuccessCodeAndInfo();
                            break;
                        case "ThenUnencryptObjectPublishShouldReturnSuccessCodeAndInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenUnencryptObjectPublishShouldReturnSuccessCodeAndInfo();
                            break;
                        case "ThenEncryptObjectPublishShouldReturnSuccessCodeAndInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenEncryptObjectPublishShouldReturnSuccessCodeAndInfo();
                            break;
                        case "ThenEncryptPublishShouldReturnSuccessCodeAndInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenEncryptPublishShouldReturnSuccessCodeAndInfo();
                            break;
                        case "ThenSecretKeyWithEncryptPublishShouldReturnSuccessCodeAndInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenSecretKeyWithEncryptPublishShouldReturnSuccessCodeAndInfo();
                            break;
                        case "ThenComplexMessageObjectShouldReturnSuccessCodeAndInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenComplexMessageObjectShouldReturnSuccessCodeAndInfo();
                            break;
                        case "ThenOptionalSecretKeyShouldBeProvidedInConstructor":
                            responseDictionary = LoadWhenAMessageIsPublishedThenOptionalSecretKeyShouldBeProvidedInConstructor();
                            break;
                        case "IfSSLNotProvidedThenDefaultShouldBeFalse":
                            responseDictionary = LoadWhenAMessageIsPublishedIfSSLNotProvidedThenDefaultShouldBeFalse();
                            break;
                        case "ThenDisableJsonEncodeShouldSendSerializedObjectMessage":
                            responseDictionary = LoadWhenAMessageIsPublishedThenDisableJsonEncodeShouldSendSerializedObjectMessage();
                            break;
                        case "ThenLargeMessageShoudFailWithMessageTooLargeInfo":
                            responseDictionary = LoadWhenAMessageIsPublishedThenLargeMessageShoudFailWithMessageTooLargeInfo();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenDetailedHistoryIsRequested":
                    switch (_testCaseName)
                    {
                        case "DetailHistoryCount10ReturnsRecords":
                            responseDictionary = LoadWhenDetailedHistoryIsRequestedDetailHistoryCount10ReturnsRecords();
                            break;
                        case "DetailHistoryCount10ReverseTrueReturnsRecords":
                            responseDictionary = LoadWhenDetailedHistoryIsRequestedDetailHistoryCount10ReverseTrueReturnsRecords();
                            break;
                        case "DetailedHistoryStartWithReverseTrue":
                            responseDictionary = LoadWhenDetailedHistoryIsRequestedDetailedHistoryStartWithReverseTrue();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenGetRequestServerTime":
                    switch (_testCaseName)
                    {
                        case "ThenItShouldReturnTimeStamp":
                            responseDictionary = LoadWhenGetRequestServerTimeThenItShouldReturnTimeStamp();
                            break;
                        case "ThenWithProxyItShouldReturnTimeStamp":
                            responseDictionary = LoadWhenGetRequestServerTimeThenWithProxyItShouldReturnTimeStamp();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenSubscribedToAChannel":
                    switch (_testCaseName)
                    {
                        case "ThenSubscribeShouldReturnReceivedMessage":
                            responseDictionary = LoadWhenSubscribedToAChannelThenSubscribeShouldReturnReceivedMessage();
                            break;
                        case "ThenSubscribeShouldReturnConnectStatus":
                            responseDictionary = LoadWhenSubscribedToAChannelThenSubscribeShouldReturnConnectStatus();
                            break;
                        case "ThenMultiSubscribeShouldReturnConnectStatus":
                            responseDictionary = LoadWhenSubscribedToAChannelThenMultiSubscribeShouldReturnConnectStatus();
                            break;
                        case "ThenDuplicateChannelShouldReturnAlreadySubscribed":
                            responseDictionary = LoadWhenSubscribedToAChannelThenDuplicateChannelShouldReturnAlreadySubscribed();
                            break;
                        case "ThenSubscriberShouldBeAbleToReceiveManyMessages":
                            responseDictionary = LoadWhenSubscribedToAChannelThenSubscriberShouldBeAbleToReceiveManyMessages();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenUnsubscribedToAChannel":
                    switch (_testCaseName)
                    {
                        case "ThenShouldReturnUnsubscribedMessage":
                            responseDictionary = LoadWhenUnsubscribedToAChannelThenShouldReturnUnsubscribedMessage();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenAuditIsRequested":
                    switch (_testCaseName)
                    {
                        case "ThenSubKeyLevelShouldReturnSuccess":
                            responseDictionary = LoadWhenAuditIsRequestedThenSubKeyLevelShouldReturnSuccess();
                            break;
                        case "ThenChannelLevelShouldReturnSuccess":
                            responseDictionary = LoadWhenAuditIsRequestedThenChannelLevelShouldReturnSuccess();
                            break;
                        default:
                            break;
                    }
                    break;
                case "WhenGrantIsRequested":
                    switch (_testCaseName)
                    {
                        case "ThenSubKeyLevelWithReadWriteShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenSubKeyLevelWithReadWriteShouldReturnSuccess();
                            break;
                        case "ThenSubKeyLevelWithReadShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenSubKeyLevelWithReadShouldReturnSuccess();
                            break;
                        case "ThenSubKeyLevelWithWriteShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenSubKeyLevelWithWriteShouldReturnSuccess();
                            break;
                        case "ThenChannelLevelWithReadWriteShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenChannelLevelWithReadWriteShouldReturnSuccess();
                            break;
                        case "ThenChannelLevelWithReadShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenChannelLevelWithReadShouldReturnSuccess();
                            break;
                        case "ThenChannelLevelWithWriteShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenChannelLevelWithWriteShouldReturnSuccess();
                            break;
                        case "ThenUserLevelWithReadWriteShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenUserLevelWithReadWriteShouldReturnSuccess();
                            break;
                        case "ThenUserLevelWithReadShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenUserLevelWithReadShouldReturnSuccess();
                            break;
                        case "ThenUserLevelWithWriteShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenUserLevelWithWriteShouldReturnSuccess();
                            break;
                        case "ThenMultipleChannelGrantShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenMultipleChannelGrantShouldReturnSuccess();
                            break;
                        case "ThenMultipleAuthGrantShouldReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenMultipleAuthGrantShouldReturnSuccess();
                            break;
                        case "ThenRevokeAtSubKeyLevelReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenRevokeAtSubKeyLevelReturnSuccess();
                            break;
                        case "ThenRevokeAtChannelLevelReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenRevokeAtChannelLevelReturnSuccess();
                            break;
                        case "ThenRevokeAtUserLevelReturnSuccess":
                            responseDictionary = LoadWhenGrantIsRequestedThenRevokeAtUserLevelReturnSuccess();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (responseDictionary != null && responseDictionary.ContainsKey(requestUri.AbsolutePath))
            {
                stubResponse = responseDictionary[requestUri.AbsolutePath];
                if (_testClassName == "WhenAMessageIsPublished" && _testCaseName == "ThenLargeMessageShoudFailWithMessageTooLargeInfo")
                {
                    PubnubWebResponse stubWebResponse = new PubnubWebResponse(new MemoryStream(Encoding.UTF8.GetBytes(stubResponse)), HttpStatusCode.BadRequest);
#if (SILVERLIGHT || WINDOWS_PHONE || NETFX_CORE)
                    WebException largeMessageException = new WebException("The remote server returned an error: (400) Bad Request", null, WebExceptionStatus.Pending, stubWebResponse);
#else
                    WebException largeMessageException = new WebException("The remote server returned an error: (400) Bad Request", null, WebExceptionStatus.ProtocolError, stubWebResponse);
#endif
                    throw largeMessageException;
                }
            }
            else
            {
                stubResponse = "[]";
            }
            //if (stubResponse == "!! Stub Response Not Assigned !!")
            //{
            //    System.Diagnostics.Debug.WriteLine("requestUri.AbsolutePath = " + requestUri.AbsolutePath);
            //    System.Diagnostics.Debug.WriteLine("stubResponse = " + stubResponse);
            //}
            return stubResponse;
        }

        public string TestCaseName
        {
            get
            {
                return _testCaseName;
            }
            set
            {
                _testCaseName = value;
            }
        }


        public string TestClassName
        {
            get
            {
                return _testClassName;
            }
            set
            {
                _testClassName = value;
            }
        }
    }
}
