using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Bytewizer.Backblaze.Models
{
    /// <summary>
    /// Contains information to create a get <see cref="GetDownloadUrlByFileNameRequest"/>.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    public class GetDownloadUrlByFileNameRequest
    {
         /// <summary>
        /// Initializes a new instance of the <see cref="GetDownloadUrlByFileNameRequest"/> class.
        /// </summary>
        /// <param name="bucketId">The bucket id which contains the file.</param>
        /// <param name="fileName">The file name the download URL will allow access.</param>
        /// <param name="validDurationInSeconds">The number of seconds before the download URL will expire.</param>
        public GetDownloadUrlByFileNameRequest(string bucketId, string fileName, long validDurationInSeconds = 3600)
        {
            // Validate required arguments
            if (string.IsNullOrWhiteSpace(bucketId))
                throw new ArgumentException("Argument can not be null, empty, or consist only of white-space characters.", nameof(bucketId));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("Argument can not be null, empty, or consist only of white-space characters.", nameof(fileName));

            if (validDurationInSeconds < 1 || validDurationInSeconds > 604800)
                throw new ArgumentOutOfRangeException($"Argument must be a minimum of 1 second and a maximum of 604800 seconds (1000 days)", nameof(validDurationInSeconds));

            // Initialize and set required properties
            BucketId = bucketId;
            FileName = fileName;
            ValidDurationInSeconds = validDurationInSeconds;
        }

        /// <summary>
        /// The bucket id.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string BucketId { get; private set; }

        /// <summary>
        /// The file name the download URL will allow access.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string FileName { get; private set; }

        /// <summary>
        /// The number of seconds before the download URL will expire. The minimum value is 1 second.
        /// The maximum value is 604800 which is one week in seconds.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public long ValidDurationInSeconds { get; private set; } = 3600;

        /// <summary>
        /// If this is present B2 will use it as the value of the Content-Disposition header when the file is downloaded
        /// unless it's overridden by a value given in the download request. Parameter continuations (contain an '*') are not supported.
        /// </summary>
        /// <remarks>
        /// Note that this file info will not be included in downloads as a x-bz-info-b2-content-disposition header.
        /// Instead, it (or the value specified in a request) will be in the Content-Disposition
        /// </remarks>
        [JsonIgnore]
        public ContentDispositionHeaderValue ContentDisposition
        {
            get { return ContentDispositionHeaderValue.Parse(B2ContentDisposition); }
            set { B2ContentDisposition = value.ToString(); }
        }

        [JsonProperty]
        private string B2ContentDisposition { get; set; }


        ///	<summary>
        ///	Debugger display for this object.
        ///	</summary>
        [JsonIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay => $"{{{nameof(BucketId)}: {BucketId}}}";
    }
}
