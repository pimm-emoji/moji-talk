using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    The Branch Class
    Contains flow branch data
*/
/// <summary>
/// The Branch Class.
/// Contains flow branch data.
/// <example>
/// <code>
/// Branch branch = new Branch();
/// branch.divider = {-50, 0, 50};
/// branch.index = {2, 3, 4, 5};
/// </code>
/// <code>
/// Branch branch = new Branch(
///     {-50, 0, 50},
///     {2, 3, 4, 5}
/// );
/// </code>
/// </example>
/// <item>
/// <term>divider</term>
/// <description>Internal Mood Parameter divider.</description>
/// </item>
/// <item>
/// <term>index</term>
/// <description>
/// Defines the next flow to go to based on the divider result.
/// </description>
/// </item>
/// </summary>
[System.Serializable]
public class Branch
{
    /// <summary>
    /// Internal Mood Parameter divider.
    /// </summary>
    public float[] divider;

    /// <summary>
    /// Defines the next flow to go to based on the divider result.
    /// The <c>index</c> must be 1 longer than the <c>divider</c>. 
    /// </summary>
    /// <remarks>
    /// The <c>index</c> must be 1 longer than the <c>divider</c>.
    /// </remarks>
    public int[] index;

    public Branch(){}
    public Branch(float[] Divider, int[] Index)
    {
        divider = Divider;
        index = Index;
    }
}
