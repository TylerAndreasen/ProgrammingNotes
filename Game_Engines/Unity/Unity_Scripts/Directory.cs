using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directory : MonoBehaviour
{
    private Page assignedPage;
    private int directoryIndex;
    private Page[] indexedPages;
    private string[] indexedActions;

    public Directory(Page passInAssignedPage, int passInDirectoryIndex, Page[] passInIndexedPages, string[] passInIndexedActions) => (assignedPage, directoryIndex, indexedPages, indexedActions) = (passInAssignedPage, passInDirectoryIndex, passInIndexedPages, passInIndexedActions);

    /*public Directory(Page passInAssignedPage, int passInDirectoryIndex, Page[] passInIndexedPages, string[] passInIndexedActions, TraitRequirement[] passInindexedTraits) => (assignedPage, directoryIndex, indexedPages, indexedActions) = (passInAssignedPage, passInDirectoryIndex, passInIndexedPages, passInIndexedActions);*/
}
