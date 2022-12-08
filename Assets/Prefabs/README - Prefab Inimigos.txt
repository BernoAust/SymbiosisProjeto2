AO PROGRAMAR INIMIGOS, ADICIONAR AS SEGUINTES LINHAS DE CÓDIGO EM SEUS RESPECTIVOS LOCAIS.
////////////////////////////////////////////////////////////////////////////////////////////////////////

=====ESCORPIÃO:=====

> QUANDO PLAYER COLIDIR PARA DESTRUIR O INIMIGO:

AudioEvent.playAudio.Invoke("Destroy_AnimalHostil");

AudioEvent.playAudio.Invoke("Attack_Slime1");

PlayerEvents.playerConsumeObject.Invoke(Points);

-------------------------------------

> QUANDO ESCORPIÃO REALIZAR UM ATAQUE

animator.Play("ScorpionAttack");

AudioEvent.playAudio.Invoke("Attack_Escorpiao");

////////////////////////////////////////////////////////////////////////////////////////////////////////

=====SOLDADO:=====

> QUANDO PLAYER COLIDIR PARA DESTRUIR O INIMIGO:

AudioEvent.playAudio.Invoke("Destroy_Soldado");

AudioEvent.playAudio.Invoke("Attack_Slime2");

PlayerEvents.playerConsumeObject.Invoke(Points);

-------------------------------------

> QUANDO SOLDADO REALIZAR UM ATAQUE

O soldado tem no animador uma bool chamada isAttackMode. Quando ativa, ele entra na Blend Tree de ataque. Quando false, ele volta para idle.

Blend Tree idle só tem soldado para frente, Gustavo não mandou no momento q fiz a lateral.

AudioEvent.playAudio.Invoke("Attack_Soldado");

////////////////////////////////////////////////////////////////////////////////////////////////////////

=====TANQUE:=====

> QUANDO PLAYER COLIDIR PARA DESTRUIR O INIMIGO:

AudioEvent.playAudio.Invoke("Destroy_Tanque");

AudioEvent.playAudio.Invoke("Attack_Slime3");

PlayerEvents.playerConsumeObject.Invoke(Points);

-------------------------------------

> QUANDO TANQUE REALIZAR UM ATAQUE

Tanque não possui animação de ataque por enquanto, vai depender do gustavo.

AudioEvent.playAudio.Invoke("Attack_Tanque");

////////////////////////////////////////////////////////////////////////////////////////////////////////