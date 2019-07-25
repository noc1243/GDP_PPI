using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    //Variaveis de controle
    [SerializeField] private float initialHealth = 100.0f;
    [SerializeField] private float damageTakenPerHit = 20.0f;
    [SerializeField] private float initialDefense = 0.0f;
    [SerializeField] private float corretorDePosicaoBarraDeHP = 45.0f;
    [SerializeField] private float timeOfInvincibility = 5.0f;

    //Lida Com o GameOver
    [SerializeField] private GameObject gameOverUI;

    //Variaveis de estado
    private float actualHealth;
    private float actualDefense;
    private float timeWithInvincibility;
    private bool tookDamage;

    //Variaveis do canvas
    [SerializeField] private RawImage hpBar;
    private float initialHpBarSize;

    // Start is called before the first frame update
    void Start () {
        this.actualHealth = this.initialHealth;
        this.actualDefense = this.initialDefense;

        this.initialHpBarSize = this.hpBar.rectTransform.rect.width;

        this.tookDamage = false;
        this.timeWithInvincibility = 0.0f;
    }

    private void limpaInvencibilidade () {
        if (this.tookDamage) {
            this.timeWithInvincibility += Time.deltaTime;

            if (timeWithInvincibility >= this.timeOfInvincibility) {
                timeWithInvincibility = 0.0f;

                tookDamage = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        limpaInvencibilidade ();
    }

    private void gameOver () {
        Debug.Log ("Game Over!!!");
        gameOverUI.active = true;

        Time.timeScale = 0.0f;
    }

    private void atualizaTamanhoBarraDeHP () {
        float novoTamanhoBarraDeHP = (this.initialHpBarSize * this.actualHealth) / this.initialHealth;

        float unidadesMovidasPraDireita = corretorDePosicaoBarraDeHP * ((this.hpBar.rectTransform.rect.width - novoTamanhoBarraDeHP) / damageTakenPerHit);

        this.hpBar.rectTransform.sizeDelta = new Vector2 (novoTamanhoBarraDeHP, this.hpBar.rectTransform.rect.height);
        this.hpBar.rectTransform.transform.position = new Vector3 (this.hpBar.rectTransform.transform.position.x + unidadesMovidasPraDireita, this.hpBar.rectTransform.transform.position.y, this.hpBar.rectTransform.transform.position.z);
    }

    private void deduzDanoDoHp () {
        this.actualHealth = this.actualHealth - this.damageTakenPerHit + this.actualDefense;

        atualizaTamanhoBarraDeHP ();

        if (this.actualHealth <= 0.0f) {
            this.gameOver ();
        }
    }

    public void recuperaHP (float quantidadeRecuperada) {
        this.actualHealth = this.actualHealth + quantidadeRecuperada;

        atualizaTamanhoBarraDeHP ();
    }

    void OnControllerColliderHit (ControllerColliderHit hit) {
        if (hit.gameObject.CompareTag ("Damage") && !this.tookDamage) {
            this.tookDamage = true;
            deduzDanoDoHp ();
        }
    }

}