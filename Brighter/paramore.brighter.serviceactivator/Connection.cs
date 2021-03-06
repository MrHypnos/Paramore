﻿// ***********************************************************************
// Assembly         : paramore.brighter.serviceactivator
// Author           : ian
// Created          : 07-01-2014
//
// Last Modified By : ian
// Last Modified On : 07-29-2014
// ***********************************************************************
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

#region Licence
/* The MIT License (MIT)
Copyright © 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

#endregion

using System;
using paramore.brighter.commandprocessor;

namespace paramore.brighter.serviceactivator
{
    /// <summary>
    /// Class Connection.
    /// A <see cref="Connection"/> holds the configuration details of the relationship between a channel provided by a broker, and a <see cref="Command"/> or <see cref="Event"/>. 
    /// It holds information on the number of threads to use to process <see cref="Message"/>s on the channel, turning them into <see cref="Command"/>s or <see cref="Event"/>s 
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public ConnectionName Name { get; set; }
        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <value>The channel.</value>
        public IAmAnInputChannel Channel { get; private set; }
        /// <summary>
        /// Gets the type of the <see cref="IRequest"/> that <see cref="Message"/>s on the <see cref="Channel"/> can be translated into.
        /// </summary>
        /// <value>The type of the data.</value>
        public Type DataType { get; private set; }
        /// <summary>
        /// Gets the no of peformers.
        /// </summary>
        /// <value>The no of peformers.</value>
        public int NoOfPeformers { get; private set; }
        /// <summary>
        /// Gets the timeout in miliseconds.
        /// </summary>
        /// <value>The timeout in miliseconds.</value>
        public int TimeoutInMiliseconds { get; private set; }
        public int RequeueCount { get; private set; }
        /// <summary>
        /// Gets the unacceptable messages limit
        /// </summary>
        public int UnacceptableMessageLimit { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Connection"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="noOfPerformers">The no of performers.</param>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds.</param>
        /// <param name="requeueCount">The number of times you want to requeue a message before dropping it</param>
        /// <param name="unacceptableMessageLimit">The number of unacceptable messages to handle, before stopping reading from the channel</param>
        public Connection(ConnectionName name, IAmAnInputChannel channel, Type dataType, int noOfPerformers = 1, int timeoutInMilliseconds = 300, int requeueCount = -1, int unacceptableMessageLimit = 0)
        {
            RequeueCount = requeueCount;
            Name = name;
            Channel = channel;
            DataType = dataType;
            NoOfPeformers = noOfPerformers;
            TimeoutInMiliseconds = timeoutInMilliseconds;
            UnacceptableMessageLimit = unacceptableMessageLimit;
        }
    }
}