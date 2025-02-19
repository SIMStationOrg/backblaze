using System.Diagnostics;

using Newtonsoft.Json;

namespace Bytewizer.Backblaze.Models
{
    /// <summary>
    /// Contains the results of a <see cref="GetDownloadUrlByFileNameResponse"/> operation.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    public class GetDownloadUrlByFileNameResponse : IResponse
    {
        /// <summary>
        /// The unique id of the bucket.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string BucketId { get; internal set; }

        /// <summary>
        /// The file name the download URL will allow <see cref="GetDownloadUrlByFileNameRequest"/> to access.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string FileName { get; internal set; }

        /// <summary>
        /// The authorization token that can be passed in the Authorization header or as an Authorization
        /// parameter to <see cref="DownloadFileByNameRequest"/> to access files beginning with the file name prefix.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string AuthorizationToken { get; internal set; }

        /// <summary>
        /// The Download URL to access the file.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public string DownloadUrl { get; internal set; }

        ///	<summary>
        ///	Debugger display for this object.
        ///	</summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay =>
            $"{{{nameof(BucketId)}: {BucketId}, {nameof(FileName)}: {FileName}, {nameof(AuthorizationToken)}: {AuthorizationToken}, {nameof(DownloadUrl)}: {DownloadUrl}}}";
    }
}
