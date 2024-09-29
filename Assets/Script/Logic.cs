using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Logic : MonoBehaviour
{
	[SerializeField]
	private PlantManager _plantManager = new PlantManager();
	[SerializeField]
	private FieldManager _fieldManager = new FieldManager();
	[SerializeField]
	private ResourceManager _resourceManager = new ResourceManager();
	[SerializeField]
	private UIManager _UIManager = new UIManager();

	public static FieldManager FieldManager { get; private set; }
	public static PlantManager PlantManager { get; private set; }
	public static ResourceManager ResourceManager { get; private set; }
	public static UIManager UIManager { get; private set; }

	public static event EventHandler OnTick;
	private float timer = 0f;
	private float interval = 0.05f;
	void Awake()
	{
		FieldManager = _fieldManager;
		PlantManager = _plantManager;
		ResourceManager = _resourceManager;
		UIManager = _UIManager;
		OnTick?.Invoke(this, EventArgs.Empty);
	}
	void Start()
	{
		_resourceManager.IncreaseSeed(_plantManager.GetPlantList()[0]);
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer < interval) return;

		OnTick?.Invoke(this, EventArgs.Empty);
		timer = 0;
	}
}
