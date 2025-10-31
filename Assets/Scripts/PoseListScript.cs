using System.Collections.Generic;
using UnityEngine;
using static PoseDetectorScript;

public class PoseListScript : MonoBehaviour
{
    public RoundManager roundManager;

    public PoseModelHelper[] poseList;
    public PoseModelHelper avataroneModel;
    public PoseModelHelper avatartwoModel;
    string player1 = "player one";
    string player2 = "player two";
    public string[] poseNames;
    public float matchThreshold = 0.7f;

    // whether the pose is matched or not
    private bool bPoseMatched = false;
    // match percent (between 0 and 1)
    private float fMatchPercent = 0f;
    // pose-time with best matching
    private float fMatchPoseTime = 0f;
    public class PoseModelData
    {
        public float fTime;
        public Vector3[] avBoneDirs;
    }
    //public PoseDetectorScript.PoseModelData[] poseDataList;
    public PoseModelData[] poseDataList;
    public List<KinectInterop.JointType> poseJoints = new List<KinectInterop.JointType>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //poseDataList = new PoseDetectorScript.PoseModelData[poseList.Length];
        poseDataList = new PoseModelData[poseList.Length];
        AddAllPoses();
    }
    private void AddAllPoses()
    {
        KinectManager kinectManager = KinectManager.Instance;
        //if (kinectManager == null || poseModel == null || poseJoints == null)
        //    return;
        for (int j = 0; j < poseList.Length; j++)
        {
            PoseModelHelper poseModel;
            poseModel = poseList[j];
            PoseModelData pose = new PoseModelData();
            pose.fTime = Time.time;
            pose.avBoneDirs = new Vector3[poseJoints.Count];

            // save model rotation
            Quaternion poseSavedRotation = poseModel.GetBoneTransform(0).rotation;
            poseModel.GetBoneTransform(0).rotation = avataroneModel.GetBoneTransform(0).rotation;
            poseModel.GetBoneTransform(0).rotation = avatartwoModel.GetBoneTransform(0).rotation;

            for (int i = 0; i < poseJoints.Count; i++)
            {
                KinectInterop.JointType joint = poseJoints[i];
                KinectInterop.JointType nextJoint = kinectManager.GetNextJoint(joint);

                if (nextJoint != joint && (int)nextJoint >= 0 && (int)nextJoint < KinectInterop.Constants.MaxJointCount)
                {
                    Transform poseTransform1 = poseModel.GetBoneTransform(poseModel.GetBoneIndexByJoint(joint, false));
                    Transform poseTransform2 = poseModel.GetBoneTransform(poseModel.GetBoneIndexByJoint(nextJoint, false));

                    if (poseTransform1 != null && poseTransform2 != null)
                    {
                        pose.avBoneDirs[i] = (poseTransform2.position - poseTransform1.position).normalized;
                    }
                }
            }

            // add pose to the list
            poseDataList[j] = pose;
            // restore model rotation
            poseModel.GetBoneTransform(0).rotation = poseSavedRotation;
        }
    }
    // Update is called once per frame
    void Update()
    {
        PoseModelData playeronePose = new PoseModelData();
        PoseModelData playertwoPose = new PoseModelData();
        
        GetAvatarPose(Time.time, false, playeronePose, avataroneModel);
        GetAvatarPose(Time.time, false, playertwoPose, avatartwoModel);
        GetPoseDifference(false, playeronePose,player1);
        GetPoseDifference(false, playertwoPose,player2);
    }

    private void GetAvatarPose(float fCurrentTime, bool isMirrored, PoseModelData poseAvatar, PoseModelHelper avatarModel)
    {
        KinectManager kinectManager = KinectManager.Instance;
        if (kinectManager == null || avatarModel == null || poseJoints == null)
            return;

        poseAvatar.fTime = fCurrentTime;
        if (poseAvatar.avBoneDirs == null)
        {
            poseAvatar.avBoneDirs = new Vector3[poseJoints.Count];
        }

        for (int i = 0; i < poseJoints.Count; i++)
        {
            KinectInterop.JointType joint = poseJoints[i];
            KinectInterop.JointType nextJoint = kinectManager.GetNextJoint(joint);

            if (nextJoint != joint && (int)nextJoint >= 0 && (int)nextJoint < KinectInterop.Constants.MaxJointCount)
            {
                Transform avatarTransform1 = avatarModel.GetBoneTransform(avatarModel.GetBoneIndexByJoint(joint, isMirrored));
                Transform avatarTransform2 = avatarModel.GetBoneTransform(avatarModel.GetBoneIndexByJoint(nextJoint, isMirrored));

                if (avatarTransform1 != null && avatarTransform2 != null)
                {
                    poseAvatar.avBoneDirs[i] = (avatarTransform2.position - avatarTransform1.position).normalized;
                }
            }
        }
    }
    private void GetPoseDifference(bool isMirrored, PoseModelData poseAvatar, string playerName)
    {
        // by-default values
        bPoseMatched = false;
        fMatchPercent = 0.7f;
        fMatchPoseTime = 0f;

        KinectManager kinectManager = KinectManager.Instance;
        if (poseJoints == null || poseAvatar.avBoneDirs == null)
            return;

        // check the difference with saved poses, starting from the last one
        for (int p = poseDataList.Length - 1; p >= 0; p--)
        {
            float fAngleDiff = 0f;
            float fMaxDiff = 0f;

            PoseModelData poseModel = poseDataList[p];
            for (int i = 0; i < poseJoints.Count; i++)
            {
                Vector3 vPoseBone = poseModel.avBoneDirs[i];
                Vector3 vAvatarBone = poseAvatar.avBoneDirs[i];

                float fDiff = Vector3.Angle(vPoseBone, vAvatarBone);
                if (fDiff > 90f)
                    fDiff = 90f;

                fAngleDiff += fDiff;
                fMaxDiff += 90f;  // we assume the max diff could be 90 degrees
            }

            float PlayerOnefPoseMatch = fMaxDiff > 0f ? (1f - fAngleDiff / fMaxDiff) : 0f;
            //float PlayerTwofPoseMatch = fMaxDiff > 0f ? (1f - fAngleDiff / fMaxDiff) : 0f;
            if (PlayerOnefPoseMatch > fMatchPercent)
            {
                Debug.Log(playerName + "pose is " + poseNames[p] + PlayerOnefPoseMatch);
                fMatchPercent = PlayerOnefPoseMatch;
                fMatchPoseTime = poseModel.fTime;
                bPoseMatched = (fMatchPercent >= matchThreshold);
            }

        }
    }
}
