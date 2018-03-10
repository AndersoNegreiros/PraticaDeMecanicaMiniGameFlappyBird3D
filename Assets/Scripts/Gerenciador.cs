using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gerenciador : MonoBehaviour {

    public GameObject arbusto;
    public GameObject canos;
    public GameObject cerca;
    public GameObject nuvem;
    public GameObject pedra;

    public GameObject particulas;

    public GameObject jogadorFelpudo;

    public Text textoScore;

    int pontuacao;

    bool comecou;
    bool acabou;

    // Use this for initialization
    void Start () {

        Physics.gravity = new Vector3(0.0f, -20.0f, 0.0f);
        textoScore.fontSize = 30;
        textoScore.text = "Toque para iniciar";
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            if (!acabou)
            {
                if (!comecou)
                {
                    comecou = true;
                    InvokeRepeating("CriaCerca", 1, 0.4f);
                    InvokeRepeating("CriaObjetos", 1, 0.75f);

                    jogadorFelpudo.GetComponent<Rigidbody>().useGravity = true;
                    jogadorFelpudo.GetComponent<Rigidbody>().isKinematic = false;


                    textoScore.text = pontuacao.ToString();
                    textoScore.fontSize = 70;
                }

                VoaFelpudo();
            }

           
        }

        jogadorFelpudo.transform.rotation = Quaternion.Euler(jogadorFelpudo.GetComponent<Rigidbody>().velocity.y * -2, 0, 0);

	}

    void CriaCerca()
    {
        Instantiate(cerca);
    }

    void CriaObjetos()
    {
        int sorteiaObjetos = Random.Range(1, 5);

        float posicaoXRandom = Random.Range(-3.5f, 2.0f);
        float posicaoYRandom = Random.Range(4f, 7f);
        float rotacaoYRandom = Random.Range(-0.0f, 360.0f);

        GameObject novoObjeto = new GameObject ();

        switch (sorteiaObjetos)

        {
            case 1: novoObjeto = Instantiate(arbusto); posicaoYRandom = novoObjeto.transform.position.y; break;
            case 2: novoObjeto = Instantiate(canos); posicaoYRandom = Random.Range(-2.0f, -0.1f); posicaoXRandom = novoObjeto.transform.position.x; break;
            case 3: novoObjeto = Instantiate(nuvem); break;
            case 4: novoObjeto = Instantiate(pedra); posicaoYRandom = novoObjeto.transform.position.y; break;
            default: break;
        }

        novoObjeto.transform.position = new Vector3(posicaoXRandom, posicaoYRandom, novoObjeto.transform.position.z);
        novoObjeto.transform.rotation = Quaternion.Euler(novoObjeto.transform.rotation.x, rotacaoYRandom, novoObjeto.transform.rotation.y);




        //{
        //    case 1:
        //        novoObjeto = (GameObject)Instantiate(pedra); posicaoYRandom = 0;
        //        break;

        //    case 2:
        //        novoObjeto = (GameObject)Instantiate(arbusto); posicaoYRandom = 0;
        //        break;

        //    case 3:
        //        novoObjeto = (GameObject)Instantiate(nuvem);
        //        break;
        //    case 4:
        //        CriaCanos();
        //        break;
        //    default: break;
        //}

        //novoObjeto.transform.position = new Vector3(novoObjeto.transform.position.x, novoObjeto.transform.position.y + posicaoYRandom, novoObjeto.transform.position.z + posicaoZRandom);
        //novoObjeto.transform.rotation = Quaternion.Euler(novoObjeto.transform.rotation.x, rotacaoYRandom, novoObjeto.transform.rotation.z);



    }


    //void CriaCanos()
    //{
    //    if (!acabou)
    //    {
    //        GameObject novoObjeto = (GameObject)Instantiate(canos);
    //        float posicaoYRandom = Random.Range(1.8f, 4.0f);
    //        novoObjeto.transform.position = new Vector3(novoObjeto.transform.position.x, posicaoYRandom, novoObjeto.transform.position.z);

    //    }
    //}



    void VoaFelpudo()
    {
        GameObject novasParticulas = Instantiate(particulas);
        novasParticulas.transform.position = jogadorFelpudo.transform.position;

        jogadorFelpudo.GetComponent<Rigidbody>().velocity = Vector3.zero;
        jogadorFelpudo.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 10.0f, 0.0f);
        jogadorFelpudo.SendMessage("SomVoa");
    }

    void MarcaPonto()
    {
        pontuacao++;
        textoScore.text = pontuacao.ToString();
    }

    void FimDeJogo()
    {
        acabou = true;
        CancelInvoke("CriaCerca");
        CancelInvoke("CriaObjetos");
        Invoke("RecarregaCena",1);
    }

    void RecarregaCena()
    {
        print("entrou em recarregar cena.");
        SceneManager.LoadScene("GamePlay");
    }

}
