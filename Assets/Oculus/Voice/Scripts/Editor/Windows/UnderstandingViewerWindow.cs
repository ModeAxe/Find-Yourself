/**************************************************************************************************
 * Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.
 *
 * Your use of this SDK or tool is subject to the Oculus SDK License Agreement, available at
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
 * under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 **************************************************************************************************/

using Facebook.WitAi;
using Facebook.WitAi.Windows;
using UnityEngine;
using Oculus.Voice.Utility;
using Oculus.Voice.Inspectors;

namespace Oculus.Voice.Windows
{
    public class UnderstandingViewerWindow : WitUnderstandingViewer
    {
        protected override GUIContent Title => VoiceSDKStyles.UnderstandingTitle;
        protected override Texture2D HeaderIcon => VoiceSDKStyles.MainHeader;
        protected override string HeaderUrl => AppVoiceExperienceWitConfigurationEditor.GetSafeAppUrl(witConfiguration, WitStyles.WitAppEndpointType.Understanding);
    }
}
