<template>
  <div class="login" v-text="msg">
    
  </div>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  name: 'Login',
  data () {
    return {
      msg: ''
    }
  },
  created(){
    this.init();
  },
  methods:{
    init(){
      // var vue = this;
      // this.$http.get('http://localhost:83/api/Product/1')
      // .then(function (res) {
      //   console.log(res);
      //   vue.msg = res.data.name
      //   vue.$router.push({ path: 'main' })
      // })
      // .catch(function (error) {
      //   console.log(error);
      // });
      console.log(this.$store);
      this.$store.dispatch('login')     //Action 通过 store.dispatch 方法触发
      this.exit()
      this.msg = this.$store.state.login.isLogin
    },
    ...mapActions(['login','exit'])
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
