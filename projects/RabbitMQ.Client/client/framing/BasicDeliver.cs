// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 2.0.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (c) 2007-2020 VMware, Inc.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       https://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v2.0:
//
//---------------------------------------------------------------------------
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.
//
//  Copyright (c) 2007-2020 VMware, Inc.  All rights reserved.
//---------------------------------------------------------------------------

using System.Text;

namespace RabbitMQ.Client.Framing.Impl
{
    /// <summary>Autogenerated type. Private implementation class - do not use directly.</summary>
    internal sealed class BasicDeliver : Client.Impl.MethodBase
    {
        public string _consumerTag;
        public ulong _deliveryTag;
        public bool _redelivered;
        public string _exchange;
        public string _routingKey;

        string ConsumerTag => _consumerTag;
        ulong DeliveryTag => _deliveryTag;
        bool Redelivered => _redelivered;
        string Exchange => _exchange;
        string RoutingKey => _routingKey;

        public BasicDeliver() {}
        public BasicDeliver(string @ConsumerTag, ulong @DeliveryTag, bool @Redelivered, string @Exchange, string @RoutingKey)
        {
            _consumerTag = @ConsumerTag;
            _deliveryTag = @DeliveryTag;
            _redelivered = @Redelivered;
            _exchange = @Exchange;
            _routingKey = @RoutingKey;
        }

        public override ushort ProtocolClassId => ClassConstants.Basic;
        public override ushort ProtocolMethodId => BasicMethodConstants.Deliver;
        public override string ProtocolMethodName => "basic.deliver";
        public override bool HasContent => true;

        public override void ReadArgumentsFrom(ref Client.Impl.MethodArgumentReader reader)
        {
            _consumerTag = reader.ReadShortstr();
            _deliveryTag = reader.ReadLonglong();
            _redelivered = reader.ReadBit();
            _exchange = reader.ReadShortstr();
            _routingKey = reader.ReadShortstr();
        }

        public override void WriteArgumentsTo(ref Client.Impl.MethodArgumentWriter writer)
        {
            writer.WriteShortstr(_consumerTag);
            writer.WriteLonglong(_deliveryTag);
            writer.WriteBit(_redelivered);
            writer.EndBits();
            writer.WriteShortstr(_exchange);
            writer.WriteShortstr(_routingKey);
        }

        public override int GetRequiredBufferSize()
        {
            int bufferSize = 12; // bytes for length of _consumerTag, _deliveryTag, bit fields, length of _exchange, length of _routingKey
            bufferSize += Encoding.UTF8.GetByteCount(_consumerTag); // _consumerTag in bytes
            bufferSize += Encoding.UTF8.GetByteCount(_exchange); // _exchange in bytes
            bufferSize += Encoding.UTF8.GetByteCount(_routingKey); // _routingKey in bytes
            return bufferSize;
        }

        public override void AppendArgumentDebugStringTo(StringBuilder sb)
        {
            sb.Append('(');
            sb.Append(_consumerTag).Append(',');
            sb.Append(_deliveryTag).Append(',');
            sb.Append(_redelivered).Append(',');
            sb.Append(_exchange).Append(',');
            sb.Append(_routingKey);
            sb.Append(')');
        }
    }
}
