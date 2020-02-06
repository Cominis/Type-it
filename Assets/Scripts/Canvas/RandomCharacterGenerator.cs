using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomCharacterGenerator : MonoBehaviour
{
    //todo: do i need this?
    //GameObject character;
    //IEnumerator GenerateRandomCharacters()
    //{
    //    var wallCollider = GameObject.FindGameObjectWithTag(Tags.WALL).GetComponent<PolygonCollider2D>();
    //    var minX = wallCollider.bounds.min.x + 1;
    //    var maxX = wallCollider.bounds.max.x - 1;
    //    var minY = wallCollider.bounds.min.y + 1;
    //    var maxY = wallCollider.bounds.max.y - 1;
    //    for (int i = 0; i < 20; i++)
    //    {

    //        var x = UnityEngine.Random.Range(minX, maxX);
    //        var y = UnityEngine.Random.Range(minY, maxY);
    //        GameObject typedCharacter = Instantiate(character, new Vector3(x, y, 0), Quaternion.identity);
    //        typedCharacter.GetComponent<TextMeshPro>().text = Constants.characters[UnityEngine.Random.Range(0, Constants.characters.Length)].ToString();
    //        yield return new WaitForEndOfFrame();
    //        var boxCollider = typedCharacter.AddComponent<BoxCollider2D>();
    //        var letterClass = typedCharacter.GetComponent<Character>();
    //        letterClass.CharacterLength = boxCollider.bounds.size.x;
    //        boxCollider.sharedMaterial = letterClass.Material;  //todo: material is added only in this class
    //                                                            //typedLetter.GetComponent<TextMeshPro>().color = new Color(let.GetComponent<TextMeshPro>().color.r, let.GetComponent<TextMeshPro>().color.g, let.GetComponent<TextMeshPro>().color.b, 0);

    //        typedCharacter.GetComponent<RandomMovement>().Move();
    //    }
    //}
}
