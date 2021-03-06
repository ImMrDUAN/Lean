﻿/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using QuantConnect.Data.Market;

namespace QuantConnect.Algorithm.CSharp
{
    public class HourReverseSplitRegressionAlgorithm : QCAlgorithm
    {
        private Symbol _symbol;

        public override void Initialize()
        {
            SetStartDate(2013, 11, 7);
            SetEndDate(2013, 11, 8);
            SetCash(100000);
            SetBenchmark(x => 0);

            _symbol = AddEquity("VXX", Resolution.Hour).Symbol;
        }

        public void OnData(TradeBars tradeBars)
        {
            TradeBar bar;
            if (!tradeBars.TryGetValue(_symbol, out bar)) return;

            if (!Portfolio.Invested && Time.Date == EndDate.Date)
            {
                Buy(_symbol, 1);
            }
        }
    }
}
