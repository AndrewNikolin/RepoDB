﻿using RepoDb.Interfaces;
using System;
using System.Data;

namespace RepoDb.Requests
{
    /// <summary>
    /// A class that holds the value of the <i>Update</i> operation arguments.
    /// </summary>
    internal class UpdateRequest : BaseRequest, IEquatable<UpdateRequest>
    {
        private int? _hashCode = null;

        /// <summary>
        /// Creates a new instance of <i>UpdateRequest</i> object.
        /// </summary>
        /// <param name="entityType">The entity type.</param>
        /// <param name="connection">The connection object.</param>
        /// <param name="where">The query expression.</param>
        /// <param name="statementBuilder">The statement builder.</param>
        public UpdateRequest(Type entityType, IDbConnection connection, QueryGroup where = null, IStatementBuilder statementBuilder = null)
            : base(entityType, connection, statementBuilder)
        {
            Where = where;
        }

        /// <summary>
        /// Gets the query expression used.
        /// </summary>
        public QueryGroup Where { get; }

        // Equality and comparers

        /// <summary>
        /// Returns the hashcode for this <i>UpdateRequest</i>.
        /// </summary>
        /// <returns>The hashcode value.</returns>
        public override int GetHashCode()
        {
            // Make sure to return if it is already provided
            if (!ReferenceEquals(null, _hashCode))
            {
                return _hashCode.Value;
            }

            // Get first the entity hash code
            var hashCode = $"Update.{EntityType.FullName}".GetHashCode();

            // Get the properties hash codes
            if (Where != null)
            {
                hashCode += Where.GetHashCode();
            }

            // Set back the hash code value
            _hashCode = hashCode;

            // Return the actual value
            return hashCode;
        }

        /// <summary>
        /// Compares the <i>UpdateRequest</i> object equality against the given target object.
        /// </summary>
        /// <param name="obj">The object to be compared to the current object.</param>
        /// <returns>True if the instances are equals.</returns>
        public override bool Equals(object obj)
        {
            return GetHashCode() == obj?.GetHashCode();
        }

        /// <summary>
        /// Compares the <i>UpdateRequest</i> object equality against the given target object.
        /// </summary>
        /// <param name="other">The object to be compared to the current object.</param>
        /// <returns>True if the instances are equal.</returns>
        public bool Equals(UpdateRequest other)
        {
            return GetHashCode() == other?.GetHashCode();
        }

        /// <summary>
        /// Compares the equality of the two <i>UpdateRequest</i> objects.
        /// </summary>
        /// <param name="objA">The first <i>UpdateRequest</i> object.</param>
        /// <param name="objB">The second <i>UpdateRequest</i> object.</param>
        /// <returns>True if the instances are equal.</returns>
        public static bool operator ==(UpdateRequest objA, UpdateRequest objB)
        {
            if (ReferenceEquals(null, objA))
            {
                return ReferenceEquals(null, objB);
            }
            return objA?.GetHashCode() == objB?.GetHashCode();
        }

        /// <summary>
        /// Compares the inequality of the two <i>UpdateRequest</i> objects.
        /// </summary>
        /// <param name="objA">The first <i>UpdateRequest</i> object.</param>
        /// <param name="objB">The second <i>UpdateRequest</i> object.</param>
        /// <returns>True if the instances are not equal.</returns>
        public static bool operator !=(UpdateRequest objA, UpdateRequest objB)
        {
            return (objA == objB) == false;
        }
    }
}
