﻿using System.Runtime.Caching;

namespace System.Data.Entity.Caching
{
    /// <summary>
    /// Represents a set of eviction and expiration details for a specific cache entry.
    /// </summary>
    public class CachePolicy
    {
        private static readonly Lazy<CachePolicy> _current = new Lazy<CachePolicy>(() => new CachePolicy());

        private DateTimeOffset _absoluteExpiration;

        private TimeSpan _duration;

        private TimeSpan _slidingExpiration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachePolicy" /> class.
        /// </summary>
        public CachePolicy()
        {
            Mode = CacheExpirationMode.None;
            _absoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration;
            _slidingExpiration = ObjectCache.NoSlidingExpiration;
            _duration = TimeSpan.Zero;
        }

        /// <summary>
        /// Gets the default <see cref="CachePolicy" />.
        /// </summary>
        public static CachePolicy Default
        {
            get { return _current.Value; }
        }

        /// <summary>
        /// Gets or sets the cache expiration mode.
        /// </summary>
        /// <value>The cache expiration mode.</value>
        public CacheExpirationMode Mode { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates a cache entry should be evicted after a specified duration.
        /// </summary>
        public DateTimeOffset AbsoluteExpiration
        {
            get { return _absoluteExpiration; }
            set
            {
                _absoluteExpiration = value;
                Mode = CacheExpirationMode.Absolute;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates a cache entry should be evicted if it has not been accessed in a given span of
        /// time.
        /// </summary>
        public TimeSpan SlidingExpiration
        {
            get { return _slidingExpiration; }
            set
            {
                _slidingExpiration = value;
                Mode = CacheExpirationMode.Sliding;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates a cache entry should be evicted after a given span of time.
        /// </summary>
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                Mode = CacheExpirationMode.Duration;
            }
        }

        /// <summary>
        /// Creates a <see cref="CachePolicy" /> with the absolute expiration.
        /// </summary>
        /// <param name="expirationSpan">The <see cref="TimeSpan" /> used to calculate absolute expiration from now.</param>
        /// <returns>An instance of <see cref="CachePolicy" />.</returns>
        public static CachePolicy WithDurationExpiration(TimeSpan expirationSpan)
        {
            var policy = new CachePolicy
            {
                Duration = expirationSpan
            };

            return policy;
        }

        /// <summary>
        /// Creates a <see cref="CachePolicy" /> with the absolute expiration.
        /// </summary>
        /// <param name="absoluteExpiration">The absolute expiration.</param>
        /// <returns>An instance of <see cref="CachePolicy" />.</returns>
        public static CachePolicy WithAbsoluteExpiration(DateTimeOffset absoluteExpiration)
        {
            var policy = new CachePolicy
            {
                AbsoluteExpiration = absoluteExpiration
            };

            return policy;
        }

        /// <summary>
        /// Creates a <see cref="CachePolicy" /> with the sliding expiration.
        /// </summary>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        /// <returns>An instance of <see cref="CachePolicy" />.</returns>
        public static CachePolicy WithSlidingExpiration(TimeSpan slidingExpiration)
        {
            var policy = new CachePolicy
            {
                SlidingExpiration = slidingExpiration
            };

            return policy;
        }
    }
}