using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bitwise.Core.Service
{
	public class ServiceLocator : MonoBehaviour
	{
		public static ServiceLocator Instance { get; private set; }

		// ----------------------------------------------------------------------------

		private Dictionary<Type, IService> m_Services = new Dictionary<Type, IService>();

		// ----------------------------------------------------------------------------

		private void Awake()
		{
			if (null != Instance)
			{
				Debug.LogError("[ServiceLocator::Awake] Multiple ServiceLocator instances\n");
				DestroyImmediate(gameObject);
			}
			else
			{
				Instance = this;
			}

			var services = GetComponentsInChildren<IService>();
			foreach (IService service in services)
			{
				Register(service);
			}
		}

		// ----------------------------------------------------------------------------

		private void Register(IService service)
		{
			if (null == service)
			{
				Debug.LogError("[ServiceLocator::Register] received null Service\n");
				return;
			}

			var serviceType = service.GetType();

			if (false == m_Services.ContainsKey(serviceType))
			{
				m_Services.Add(serviceType, service);
				Debug.Log($"[ServiceLocator::Register] Added Service: {serviceType}\n");
			}
			else
			{
				Debug.LogError($"[ServiceLocator::Register] Service already registered: {serviceType}\n");
			}
		}

		public void Unregister(IService service)
		{
			if (null == service)
			{
				Debug.LogError("[ServiceLocator::Unregister] received null Service\n");
				return;
			}

			Type serviceType = service.GetType();

			if (m_Services.Remove(serviceType))
			{
				Debug.Log($"[ServiceLocator::Unregister] Removed Service: {serviceType}\n");
			}
			else
			{
				Debug.LogError($"[ServiceLocator::Unregister] Service not registered: {serviceType}\n");
			}
		}

		public TService Get<TService>() where TService : IService
		{
			var serviceType = typeof(TService);
			if (m_Services.TryGetValue(serviceType, out IService service))
			{
				return (TService)service;
			}
			else
			{
				Debug.LogError($"[ServiceLocator::Get] Failed to find Service: {serviceType}\n");
				return default;
			}
		}
	}
}