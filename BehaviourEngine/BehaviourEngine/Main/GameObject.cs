﻿using OpenTK;
using System.Collections.Generic;

namespace BehaviourEngine
{
    public class GameObject
    {
        public bool Active { get; set; }

        public Transform Transform;

        private List<Behaviour> behaviours;

        public GameObject()
        {
            behaviours = new List<Behaviour>();
            this.Transform = new Transform();
            this.AddBehaviour(this.Transform);
            Active = true;
        }

        public T AddBehaviour<T>(T behaviour) where T : Behaviour
        {
            behaviour.SetOwner(this);
            behaviours.Add(behaviour);

            //TODO: verify
            if (this.Active)
            {
                this.Spawn(behaviour);
            }

            return behaviour;
        }

        public T GetBehaviour<T>() where T : class
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                if (behaviours[i] is T)
                {
                    return behaviours[i] as T;
                }
            }
            return null;
        }

        public Behaviour[] GetAllBehaviours()
        {
            Behaviour[] array = new Behaviour[behaviours.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = behaviours[i];
            }
            return array;
        }

        public static GameObject Spawn(GameObject gameObject)
        {
            return gameObject.Spawn();
        }
        public static GameObject Spawn(GameObject gameObject, Vector2 position)
        {
            gameObject.Transform.Position = position;

            return GameObject.Spawn(gameObject);
        }
        public static GameObject Spawn(GameObject gameObject, Vector2 position, float eulerRotation)
        {
            gameObject.Transform.Position = position;
            gameObject.Transform.EulerRotation = eulerRotation;

            return GameObject.Spawn(gameObject);
        }
        private GameObject Spawn()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                this.Spawn(behaviours[i]);
            }
            return this;
        }
        private void Spawn(Behaviour behaviour)
        {
            Engine.Add(behaviour);
        }
    }
}