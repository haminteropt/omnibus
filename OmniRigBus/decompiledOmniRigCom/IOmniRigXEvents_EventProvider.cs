// Decompiled with JetBrains decompiler
// Type: OmniRig.IOmniRigXEvents_EventProvider
// Assembly: Interop.OmniRig, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A1646A62-CD49-43CF-8028-E3F8425A4659
// Assembly location: D:\GitHubRepos\OmniRig_VB_DEMO\OmniRig_VB_DEMO\obj\Debug\Interop.OmniRig.dll

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace OmniRig
{
    internal sealed class IOmniRigXEvents_EventProvider : IOmniRigXEvents_Event, IDisposable
    {
        private IConnectionPointContainer m_ConnectionPointContainer;
        private ArrayList m_aEventSinkHelpers;
        private IConnectionPoint m_ConnectionPoint;

        private void Init()
        {
            IConnectionPoint ppCP = (IConnectionPoint)null;
            Guid riid = new Guid(new byte[16]
            {
        (byte) 95,
        (byte) 23,
        (byte) 25,
        (byte) 34,
        (byte) 97,
        (byte) 229,
        (byte) 231,
        (byte) 71,
        (byte) 173,
        (byte) 23,
        (byte) 115,
        (byte) 196,
        (byte) 216,
        (byte) 137,
        (byte) 26,
        (byte) 161
            });
            this.m_ConnectionPointContainer.FindConnectionPoint(ref riid, out ppCP);
            this.m_ConnectionPoint = ppCP;
            this.m_aEventSinkHelpers = new ArrayList();
        }

        public virtual void add_VisibleChange([In] IOmniRigXEvents_VisibleChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_ConnectionPoint == null)
                    this.Init();
                IOmniRigXEvents_SinkHelper xeventsSinkHelper = new IOmniRigXEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object)xeventsSinkHelper, out pdwCookie);
                xeventsSinkHelper.m_dwCookie = pdwCookie;
                xeventsSinkHelper.m_VisibleChangeDelegate = obj0;
                this.m_aEventSinkHelpers.Add((object)xeventsSinkHelper);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void remove_VisibleChange([In] IOmniRigXEvents_VisibleChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_aEventSinkHelpers == null)
                    return;
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 >= count)
                    return;
                do
                {
                    IOmniRigXEvents_SinkHelper aEventSinkHelper = (IOmniRigXEvents_SinkHelper)this.m_aEventSinkHelpers[index];
                    if (aEventSinkHelper.m_VisibleChangeDelegate != null && ((aEventSinkHelper.m_VisibleChangeDelegate.Equals((object)obj0) ? 1 : 0) & (int)byte.MaxValue) != 0)
                    {
                        this.m_aEventSinkHelpers.RemoveAt(index);
                        this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
                        if (count <= 1)
                        {
                            Marshal.ReleaseComObject((object)this.m_ConnectionPoint);
                            this.m_ConnectionPoint = (IConnectionPoint)null;
                            this.m_aEventSinkHelpers = (ArrayList)null;
                            return;
                        }
                        goto label_11;
                    }
                    else
                        ++index;
                }
                while (index < count);
                goto label_12;
                label_11:
                return;
                label_12:;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void add_RigTypeChange([In] IOmniRigXEvents_RigTypeChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_ConnectionPoint == null)
                    this.Init();
                IOmniRigXEvents_SinkHelper xeventsSinkHelper = new IOmniRigXEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object)xeventsSinkHelper, out pdwCookie);
                xeventsSinkHelper.m_dwCookie = pdwCookie;
                xeventsSinkHelper.m_RigTypeChangeDelegate = obj0;
                this.m_aEventSinkHelpers.Add((object)xeventsSinkHelper);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void remove_RigTypeChange([In] IOmniRigXEvents_RigTypeChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_aEventSinkHelpers == null)
                    return;
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 >= count)
                    return;
                do
                {
                    IOmniRigXEvents_SinkHelper aEventSinkHelper = (IOmniRigXEvents_SinkHelper)this.m_aEventSinkHelpers[index];
                    if (aEventSinkHelper.m_RigTypeChangeDelegate != null && ((aEventSinkHelper.m_RigTypeChangeDelegate.Equals((object)obj0) ? 1 : 0) & (int)byte.MaxValue) != 0)
                    {
                        this.m_aEventSinkHelpers.RemoveAt(index);
                        this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
                        if (count <= 1)
                        {
                            Marshal.ReleaseComObject((object)this.m_ConnectionPoint);
                            this.m_ConnectionPoint = (IConnectionPoint)null;
                            this.m_aEventSinkHelpers = (ArrayList)null;
                            return;
                        }
                        goto label_11;
                    }
                    else
                        ++index;
                }
                while (index < count);
                goto label_12;
                label_11:
                return;
                label_12:;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void add_StatusChange([In] IOmniRigXEvents_StatusChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_ConnectionPoint == null)
                    this.Init();
                IOmniRigXEvents_SinkHelper xeventsSinkHelper = new IOmniRigXEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object)xeventsSinkHelper, out pdwCookie);
                xeventsSinkHelper.m_dwCookie = pdwCookie;
                xeventsSinkHelper.m_StatusChangeDelegate = obj0;
                this.m_aEventSinkHelpers.Add((object)xeventsSinkHelper);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void remove_StatusChange([In] IOmniRigXEvents_StatusChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_aEventSinkHelpers == null)
                    return;
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 >= count)
                    return;
                do
                {
                    IOmniRigXEvents_SinkHelper aEventSinkHelper = (IOmniRigXEvents_SinkHelper)this.m_aEventSinkHelpers[index];
                    if (aEventSinkHelper.m_StatusChangeDelegate != null && ((aEventSinkHelper.m_StatusChangeDelegate.Equals((object)obj0) ? 1 : 0) & (int)byte.MaxValue) != 0)
                    {
                        this.m_aEventSinkHelpers.RemoveAt(index);
                        this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
                        if (count <= 1)
                        {
                            Marshal.ReleaseComObject((object)this.m_ConnectionPoint);
                            this.m_ConnectionPoint = (IConnectionPoint)null;
                            this.m_aEventSinkHelpers = (ArrayList)null;
                            return;
                        }
                        goto label_11;
                    }
                    else
                        ++index;
                }
                while (index < count);
                goto label_12;
                label_11:
                return;
                label_12:;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void add_ParamsChange([In] IOmniRigXEvents_ParamsChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_ConnectionPoint == null)
                    this.Init();
                IOmniRigXEvents_SinkHelper xeventsSinkHelper = new IOmniRigXEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object)xeventsSinkHelper, out pdwCookie);
                xeventsSinkHelper.m_dwCookie = pdwCookie;
                xeventsSinkHelper.m_ParamsChangeDelegate = obj0;
                this.m_aEventSinkHelpers.Add((object)xeventsSinkHelper);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void remove_ParamsChange([In] IOmniRigXEvents_ParamsChangeEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_aEventSinkHelpers == null)
                    return;
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 >= count)
                    return;
                do
                {
                    IOmniRigXEvents_SinkHelper aEventSinkHelper = (IOmniRigXEvents_SinkHelper)this.m_aEventSinkHelpers[index];
                    if (aEventSinkHelper.m_ParamsChangeDelegate != null && ((aEventSinkHelper.m_ParamsChangeDelegate.Equals((object)obj0) ? 1 : 0) & (int)byte.MaxValue) != 0)
                    {
                        this.m_aEventSinkHelpers.RemoveAt(index);
                        this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
                        if (count <= 1)
                        {
                            Marshal.ReleaseComObject((object)this.m_ConnectionPoint);
                            this.m_ConnectionPoint = (IConnectionPoint)null;
                            this.m_aEventSinkHelpers = (ArrayList)null;
                            return;
                        }
                        goto label_11;
                    }
                    else
                        ++index;
                }
                while (index < count);
                goto label_12;
                label_11:
                return;
                label_12:;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void add_CustomReply([In] IOmniRigXEvents_CustomReplyEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_ConnectionPoint == null)
                    this.Init();
                IOmniRigXEvents_SinkHelper xeventsSinkHelper = new IOmniRigXEvents_SinkHelper();
                int pdwCookie = 0;
                this.m_ConnectionPoint.Advise((object)xeventsSinkHelper, out pdwCookie);
                xeventsSinkHelper.m_dwCookie = pdwCookie;
                xeventsSinkHelper.m_CustomReplyDelegate = obj0;
                this.m_aEventSinkHelpers.Add((object)xeventsSinkHelper);
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void remove_CustomReply([In] IOmniRigXEvents_CustomReplyEventHandler obj0)
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_aEventSinkHelpers == null)
                    return;
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 >= count)
                    return;
                do
                {
                    IOmniRigXEvents_SinkHelper aEventSinkHelper = (IOmniRigXEvents_SinkHelper)this.m_aEventSinkHelpers[index];
                    if (aEventSinkHelper.m_CustomReplyDelegate != null && ((aEventSinkHelper.m_CustomReplyDelegate.Equals((object)obj0) ? 1 : 0) & (int)byte.MaxValue) != 0)
                    {
                        this.m_aEventSinkHelpers.RemoveAt(index);
                        this.m_ConnectionPoint.Unadvise(aEventSinkHelper.m_dwCookie);
                        if (count <= 1)
                        {
                            Marshal.ReleaseComObject((object)this.m_ConnectionPoint);
                            this.m_ConnectionPoint = (IConnectionPoint)null;
                            this.m_aEventSinkHelpers = (ArrayList)null;
                            return;
                        }
                        goto label_11;
                    }
                    else
                        ++index;
                }
                while (index < count);
                goto label_12;
                label_11:
                return;
                label_12:;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public IOmniRigXEvents_EventProvider([In] object obj0)
        {
            this.m_ConnectionPointContainer = (IConnectionPointContainer)obj0;
        }

        public override void Finalize()
        {
            bool lockTaken;
            try
            {
                Monitor.Enter((object)this, ref lockTaken);
                if (this.m_ConnectionPoint == null)
                    return;
                int count = this.m_aEventSinkHelpers.Count;
                int index = 0;
                if (0 < count)
                {
                    do
                    {
                        this.m_ConnectionPoint.Unadvise(((IOmniRigXEvents_SinkHelper)this.m_aEventSinkHelpers[index]).m_dwCookie);
                        ++index;
                    }
                    while (index < count);
                }
                Marshal.ReleaseComObject((object)this.m_ConnectionPoint);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit((object)this);
            }
        }

        public virtual void Dispose()
        {
            this.Finalize();
            GC.SuppressFinalize((object)this);
        }
    }
}
