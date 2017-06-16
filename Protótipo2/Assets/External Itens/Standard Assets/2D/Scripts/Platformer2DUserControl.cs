using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		public bool crouch;
		public float h;
		public float v;

        public Collider2D col;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (crouch == true)
            {
                col.transform.localEulerAngles = new Vector3(0, 0, 90);
                col.offset = new Vector2(-0.33f, -0.05f);
            }

            else
            {
                col.transform.localEulerAngles = new Vector3(0, 0, 0);
                col.offset = new Vector2(-0.05127324f, -0.1661299f);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            // Pass all parameters to the character control script.
            m_Character.Move(h, v, crouch, m_Jump);
            m_Jump = false;
        }

		public void Agaichar(bool agaichar)
		{

			crouch = agaichar;
		}

		public void Pular(bool pulo)
		{
			m_Jump = pulo;
		}

		public void AndarEsq(float Esq)
		{
			h = -Esq;
		}

		public void AndarDir(float Dir)
		{
			h = Dir;
		}

		public void AndarCima(float Cima)
		{
			v = Cima;
		}

		public void AndarBaixo(float Baixo)
		{
			v = -Baixo;
		}
    }
}
