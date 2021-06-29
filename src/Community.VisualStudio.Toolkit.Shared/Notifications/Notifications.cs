﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
#if VS16 || VS17
using Microsoft.VisualStudio.TaskStatusCenter;
#endif

namespace Community.VisualStudio.Toolkit
{
    /// <summary>A collection of services used to notify the user.</summary>
    public partial class Notifications
    {
        internal Notifications()
        { }

#if VS16 || VS17

        /// <summary>The Task Status Center is used to run background tasks and is located in the left-most side of the status bar.</summary>
        /// <remarks>This is only available for Visual Studio 2019 (16.0).</remarks>
        public Task<IVsTaskStatusCenterService> GetTaskStatusCenterAsync() => VS.GetRequiredServiceAsync<SVsTaskStatusCenterService, IVsTaskStatusCenterService>();
#endif

        /// <summary>Used for background tasks that needs to block the UI if they take longer than the specified seconds.</summary>
        /// <returns>Cast return object to <see cref="IVsThreadedWaitDialogFactory"/>.</returns>
        public Task<object> GetThreadedWaitDialogAsync() => VS.GetRequiredServiceAsync<SVsThreadedWaitDialogFactory, object>();

        /// <summary>Used to write log messaged to the ActivityLog.xml file.</summary>
        public Task<IVsActivityLog> GetActivityLogAsync() => VS.GetRequiredServiceAsync<SVsActivityLog, IVsActivityLog>();
    }
}
