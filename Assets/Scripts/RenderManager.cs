using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour
{
    public GameObject salaControle1Static;
    public GameObject salaControle1Managed;
    public GameObject salaControle2Static;
    public GameObject salaControle2Managed;
    public GameObject salaControle3Static;
    public GameObject salaControle3Managed;
    public GameObject salaControle4Static;
    public GameObject salaControle4Managed;
    public GameObject exteriorStatic;
    public GameObject exteriorManaged;
    public GameObject arquivosStatic;
    public GameObject arquivosManaged;
    public GameObject tanquesStatic;
    public GameObject tanquesManaged;
    public GameObject manutencaoStatic;
    public GameObject manutencaoManaged;
    public GameObject labirintoStatic;
    public GameObject labirintoManaged;
    public GameObject salinhaStatic;
    public GameObject salinhaManaged;
    public GameObject bifurcacaoStatic;
    public GameObject bifurcacaoManaged;
    public GameObject armazemStatic;
    public GameObject armazemManaged;
    public GameObject laboratorioStatic;
    public GameObject laboratorioManaged;
    public GameObject chamineStatic;
    public GameObject chamineManaged;
    public GameObject corredorStatic;
    public GameObject corredorManaged;

    private int currentRenderMode;
    private int nextRenderMode;

    private bool destroyedSalaControle1Static = false;
    private bool destroyedSalaControle1Managed = false;
    private bool destroyedSalaControle2Static = false;
    private bool destroyedSalaControle2Managed = false;
    private bool destroyedSalaControle3Static = false;
    private bool destroyedSalaControle3Managed = false;
    private bool destroyedExteriorStatic = false;
    private bool destroyedExteriorManaged = false;
    private bool destroyedArquivosStatic = false;
    private bool destroyedArquivosManaged = false;
    private bool destroyedTanquesStatic = false;
    private bool destroyedTanquesManaged = false;
    private bool destroyedManutencaoStatic = false;
    private bool destroyedManutencaoManaged = false;
    private bool destroyedLabirintoStatic = false;
    private bool destroyedLabirintoManaged = false;
    private bool destroyedSalinhaStatic = false;
    private bool destroyedSalinhaManaged = false;
    private bool destroyedBifurcacaoStatic = false;
    private bool destroyedBifurcacaoManaged = false;
    private bool destroyedArmazemStatic = false;
    private bool destroyedArmazemManaged = false;
    private bool destroyedLaboratorioStatic = false;
    private bool destroyedLaboratorioManaged = false;
    private bool destroyedChamineStatic = false;
    private bool destroyedChamineManaged = false;
    private bool destroyedCorredorStatic = false;
    private bool destroyedCorredorManaged = false;

    void Update()
    {
        if (currentRenderMode != nextRenderMode)
        {
            if (nextRenderMode == 0)
            {
                if (!destroyedSalaControle1Static)
                {
                    salaControle1Static.SetActive(true);
                }

                if (!destroyedSalaControle1Managed)
                {
                    salaControle1Managed.SetActive(true);
                }

                if (!destroyedExteriorStatic)
                {
                    exteriorStatic.SetActive(false);
                }

                if (!destroyedExteriorManaged)
                {
                    exteriorManaged.SetActive(false);
                }

                if (!destroyedArquivosStatic)
                {
                    arquivosStatic.SetActive(false);
                }

                if (!destroyedArquivosManaged)
                {
                    arquivosManaged.SetActive(false);
                }

                if (!destroyedTanquesStatic)
                {
                    tanquesStatic.SetActive(false);
                }

                if (!destroyedTanquesManaged)
                {
                    tanquesManaged.SetActive(false);
                }

                if (!destroyedManutencaoStatic)
                {
                    manutencaoStatic.SetActive(false);
                }

                if (!destroyedManutencaoManaged)
                {
                    manutencaoManaged.SetActive(false);
                }

                if (!destroyedLabirintoStatic)
                {
                    labirintoStatic.SetActive(false);
                }

                currentRenderMode = 0;
            }

            if (nextRenderMode == 1)
            {
                if (!destroyedSalaControle1Static)
                {
                    salaControle1Static.SetActive(true);
                }

                if (!destroyedSalaControle1Managed)
                {
                    salaControle1Managed.SetActive(false);
                }

                if (!destroyedExteriorStatic)
                {
                    exteriorStatic.SetActive(true);
                }

                if (!destroyedExteriorManaged)
                {
                    exteriorManaged.SetActive(true);
                }

                if (!destroyedArquivosStatic)
                {
                    arquivosStatic.SetActive(true);
                }

                if (!destroyedArquivosManaged)
                {
                    arquivosManaged.SetActive(true);
                }

                if (!destroyedTanquesStatic)
                {
                    tanquesStatic.SetActive(true);
                }

                if (!destroyedTanquesManaged)
                {
                    tanquesManaged.SetActive(true);
                }

                if (!destroyedManutencaoStatic)
                {
                    manutencaoStatic.SetActive(true);
                }

                if (!destroyedManutencaoManaged)
                {
                    manutencaoManaged.SetActive(true);
                }

                if (!destroyedLabirintoStatic)
                {
                    labirintoStatic.SetActive(true);
                }

                currentRenderMode = 1;
            }

            if (nextRenderMode == 2)
            {
                if (!destroyedSalaControle1Static)
                {
                    salaControle1Static.SetActive(false);
                }

                if (!destroyedSalaControle1Managed)
                {
                    salaControle1Managed.SetActive(false);
                }

                if (!destroyedExteriorStatic)
                {
                    exteriorStatic.SetActive(false);
                }

                if (!destroyedExteriorManaged)
                {
                    exteriorManaged.SetActive(false);
                }

                if (!destroyedArquivosStatic)
                {
                    arquivosStatic.SetActive(false);
                }

                if (!destroyedArquivosManaged)
                {
                    arquivosManaged.SetActive(false);
                }

                if (!destroyedTanquesStatic)
                {
                    tanquesStatic.SetActive(false);
                }

                if (!destroyedTanquesManaged)
                {
                    tanquesManaged.SetActive(false);
                }

                if (!destroyedManutencaoStatic)
                {
                    manutencaoStatic.SetActive(true);
                }

                if (!destroyedManutencaoManaged)
                {
                    manutencaoManaged.SetActive(true);
                }

                if (!destroyedLabirintoStatic)
                {
                    labirintoStatic.SetActive(false);
                }

                if (!destroyedLabirintoManaged)
                {
                    labirintoManaged.SetActive(false);
                }

                if (!destroyedSalinhaStatic)
                {
                    salinhaStatic.SetActive(false);
                }

                if (!destroyedSalinhaManaged)
                {
                    salinhaManaged.SetActive(false);
                }

                currentRenderMode = 2;
            }

            if (nextRenderMode == 3)
            {
                if (!destroyedSalaControle1Static)
                {
                    Destroy(salaControle1Static);
                    destroyedSalaControle1Static = true;
                }

                if (!destroyedSalaControle1Managed)
                {
                    Destroy(salaControle1Managed);
                    destroyedSalaControle1Managed = true;
                }

                if (!destroyedExteriorStatic)
                {
                    Destroy(exteriorStatic);
                    destroyedExteriorStatic = true;
                }

                if (!destroyedExteriorManaged)
                {
                    Destroy(exteriorManaged);
                    destroyedExteriorManaged = true;
                }

                if (!destroyedArquivosStatic)
                {
                    Destroy(arquivosStatic);
                    destroyedArquivosStatic = true;
                }

                if (!destroyedArquivosManaged)
                {
                    Destroy(arquivosManaged);
                    destroyedArquivosManaged = true;
                }

                if (!destroyedTanquesStatic)
                {
                    Destroy(tanquesStatic);
                    destroyedTanquesStatic = true;
                }

                if (!destroyedTanquesManaged)
                {
                    Destroy(tanquesManaged);
                    destroyedTanquesManaged = true;
                }

                if (!destroyedManutencaoStatic)
                {
                    manutencaoStatic.SetActive(true);
                }

                if (!destroyedManutencaoManaged)
                {
                    manutencaoManaged.SetActive(false);
                }

                if (!destroyedLabirintoStatic)
                {
                    labirintoStatic.SetActive(true);
                }

                if (!destroyedLabirintoManaged)
                {
                    labirintoManaged.SetActive(true);
                }

                if (!destroyedSalinhaStatic)
                {
                    salinhaStatic.SetActive(true);
                }

                if (!destroyedSalinhaManaged)
                {
                    salinhaManaged.SetActive(false);
                }

                currentRenderMode = 3;
            }

            if (nextRenderMode == 4)
            {
                if (!destroyedManutencaoStatic)
                {
                    manutencaoStatic.SetActive(false);
                }

                if (!destroyedManutencaoManaged)
                {
                    manutencaoManaged.SetActive(false);
                }

                if (!destroyedLabirintoStatic)
                {
                    labirintoStatic.SetActive(false);
                }

                if (!destroyedLabirintoManaged)
                {
                    labirintoManaged.SetActive(false);
                }

                if (!destroyedSalinhaStatic)
                {
                    salinhaStatic.SetActive(true);
                }

                if (!destroyedSalinhaManaged)
                {
                    salinhaManaged.SetActive(true);
                }

                currentRenderMode = 4;
            }

            if (nextRenderMode == 5)
            {
                if (!destroyedManutencaoStatic)
                {
                    Destroy(manutencaoStatic);
                    destroyedManutencaoStatic = true;
                }

                if (!destroyedManutencaoManaged)
                {
                    Destroy(manutencaoManaged);
                    destroyedManutencaoManaged = true;
                }

                if (!destroyedLabirintoStatic)
                {
                    Destroy(labirintoStatic);
                    destroyedLabirintoStatic = true;
                }

                if (!destroyedLabirintoManaged)
                {
                    Destroy(labirintoManaged);
                    destroyedLabirintoManaged = true;
                }

                if (!destroyedSalaControle2Static)
                {
                    salaControle2Static.SetActive(true);
                }

                if (!destroyedSalaControle2Managed)
                {
                    salaControle2Managed.SetActive(true);
                }

                if (!destroyedSalinhaStatic)
                {
                    salinhaStatic.SetActive(true);
                }

                if (!destroyedSalinhaManaged)
                {
                    salinhaManaged.SetActive(false);
                }

                currentRenderMode = 5;
            }

            if (nextRenderMode == 6)
            {
                if (!destroyedSalaControle2Static)
                {
                    salaControle2Static.SetActive(true);
                }

                if (!destroyedSalaControle2Managed)
                {
                    salaControle2Managed.SetActive(false);
                }

                if (!destroyedSalinhaStatic)
                {
                    Destroy(salinhaStatic);
                    destroyedSalinhaStatic = true;
                }

                if (!destroyedSalinhaManaged)
                {
                    Destroy(salinhaManaged);
                    destroyedSalinhaManaged = true;
                }

                if (!destroyedBifurcacaoStatic)
                {
                    bifurcacaoStatic.SetActive(true);
                }

                if (!destroyedBifurcacaoManaged)
                {
                    bifurcacaoManaged.SetActive(true);
                }

                if (!destroyedArmazemStatic)
                {
                    armazemStatic.SetActive(false);
                }

                if (!destroyedArmazemManaged)
                {
                    armazemManaged.SetActive(false);
                }

                if (!destroyedLaboratorioStatic)
                {
                    laboratorioStatic.SetActive(false);
                }

                if (!destroyedLaboratorioManaged)
                {
                    laboratorioManaged.SetActive(false);
                }


                currentRenderMode = 6;
            }

            if (nextRenderMode == 7)
            {
                if (!destroyedSalaControle2Static)
                {
                    salaControle2Static.SetActive(false);
                }

                if (!destroyedSalaControle2Managed)
                {
                    salaControle2Managed.SetActive(false);
                }

                if (!destroyedBifurcacaoStatic)
                {
                    bifurcacaoStatic.SetActive(true);
                }

                if (!destroyedBifurcacaoManaged)
                {
                    bifurcacaoManaged.SetActive(false);
                }

                if (!destroyedArmazemStatic)
                {
                    armazemStatic.SetActive(true);
                }

                if (!destroyedArmazemManaged)
                {
                    armazemManaged.SetActive(true);
                }

                if (!destroyedLaboratorioStatic)
                {
                    laboratorioStatic.SetActive(false);
                }

                if (!destroyedLaboratorioManaged)
                {
                    laboratorioManaged.SetActive(false);
                }

                currentRenderMode = 7;
            }

            if (nextRenderMode == 8)
            {
                if (!destroyedSalaControle2Static)
                {
                    salaControle2Static.SetActive(false);
                }

                if (!destroyedSalaControle2Managed)
                {
                    salaControle2Managed.SetActive(false);
                }

                if (!destroyedBifurcacaoStatic)
                {
                    bifurcacaoStatic.SetActive(true);
                }

                if (!destroyedBifurcacaoManaged)
                {
                    bifurcacaoManaged.SetActive(false);
                }

                if (!destroyedArmazemStatic)
                {
                    armazemStatic.SetActive(false);
                }

                if (!destroyedArmazemManaged)
                {
                    armazemManaged.SetActive(false);
                }

                if (!destroyedLaboratorioStatic)
                {
                    laboratorioStatic.SetActive(true);
                }

                if (!destroyedLaboratorioManaged)
                {
                    laboratorioManaged.SetActive(true);
                }

                if (!destroyedChamineStatic)
                {
                    chamineStatic.SetActive(false);
                }

                if (!destroyedChamineManaged)
                {
                    chamineManaged.SetActive(false);
                }

                currentRenderMode = 8;
            }

            if (nextRenderMode == 9)
            {
                if (!destroyedSalaControle2Static)
                {
                    Destroy(salaControle2Static);
                    destroyedSalaControle2Static = true;
                }

                if (!destroyedSalaControle2Managed)
                {
                    Destroy(salaControle2Managed);
                    destroyedSalaControle2Managed = true;
                }

                if (!destroyedBifurcacaoStatic)
                {
                    Destroy(bifurcacaoStatic);
                    destroyedBifurcacaoStatic = true;
                }

                if (!destroyedBifurcacaoManaged)
                {
                    Destroy(bifurcacaoManaged);
                    destroyedBifurcacaoManaged = true;
                }

                if (!destroyedArmazemStatic)
                {
                    Destroy(armazemStatic);
                    destroyedArmazemStatic = true;
                }

                if (!destroyedArmazemManaged)
                {
                    Destroy(armazemManaged);
                    destroyedArmazemManaged = true;
                }

                if (!destroyedLaboratorioStatic)
                {
                    laboratorioStatic.SetActive(true);
                }

                if (!destroyedLaboratorioManaged)
                {
                    laboratorioManaged.SetActive(false);
                }

                if (!destroyedChamineStatic)
                {
                    chamineStatic.SetActive(true);
                }

                if (!destroyedChamineManaged)
                {
                    chamineManaged.SetActive(true);
                }

                if (!destroyedSalaControle3Static)
                {
                    salaControle3Static.SetActive(false);
                }

                if (!destroyedSalaControle3Managed)
                {
                    salaControle3Managed.SetActive(false);
                }

                currentRenderMode = 9;
            }

            if (nextRenderMode == 10)
            {
                if (!destroyedLaboratorioStatic)
                {
                    Destroy(laboratorioStatic);
                    destroyedLaboratorioStatic = true;
                }

                if (!destroyedLaboratorioManaged)
                {
                    Destroy(laboratorioManaged);
                    destroyedLaboratorioManaged = true;
                }

                if (!destroyedChamineStatic)
                {
                    chamineStatic.SetActive(true);
                }

                if (!destroyedChamineManaged)
                {
                    chamineManaged.SetActive(false);
                }

                if (!destroyedSalaControle3Static)
                {
                    salaControle3Static.SetActive(true);
                }

                if (!destroyedSalaControle3Managed)
                {
                    salaControle3Managed.SetActive(true);
                }

                if (!destroyedCorredorStatic)
                {
                    corredorStatic.SetActive(false);
                }

                if (!destroyedCorredorManaged)
                {
                    corredorManaged.SetActive(false);
                }

                salaControle4Static.SetActive(false);
                salaControle4Managed.SetActive(false);

                currentRenderMode = 10;
            }

            if (nextRenderMode == 11)
            {
                if (!destroyedChamineStatic)
                {
                    Destroy(chamineStatic);
                    destroyedChamineStatic = true;
                }

                if (!destroyedChamineManaged)
                {
                    Destroy(chamineManaged);
                    destroyedChamineManaged = true;
                }

                if (!destroyedSalaControle3Static)
                {
                    salaControle3Static.SetActive(true);
                }

                if (!destroyedSalaControle3Managed)
                {
                    salaControle3Managed.SetActive(false);
                }

                if (!destroyedCorredorStatic)
                {
                    corredorStatic.SetActive(true);
                }

                if (!destroyedCorredorManaged)
                {
                    corredorManaged.SetActive(true);
                }
                
                salaControle4Static.SetActive(true);
                salaControle4Managed.SetActive(false);

                currentRenderMode = 11;
            }

            if (nextRenderMode == 12)
            {
                if (!destroyedSalaControle3Static)
                {
                    Destroy(salaControle3Static);
                    destroyedSalaControle3Static = true;
                }

                if (!destroyedSalaControle3Managed)
                {
                    Destroy(salaControle3Managed);
                    destroyedSalaControle3Managed = true;
                }

                if (!destroyedCorredorStatic)
                {
                    Destroy(corredorStatic);
                    destroyedCorredorStatic = true;
                }

                if (!destroyedCorredorManaged)
                {
                    Destroy(corredorManaged);
                    destroyedCorredorManaged = true;
                }

                salaControle4Static.SetActive(true);
                salaControle4Managed.SetActive(true);

                currentRenderMode = 12;
            }
        }
    }



    public void ChangeRenderMode(int nextMode)
    {
        if (nextRenderMode != nextMode) nextRenderMode = nextMode;
    }
}
